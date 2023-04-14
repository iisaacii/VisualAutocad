Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles

Module codigo
    'Conexion a AUTOCAD
    Public Sub ConectarConAutoCAD()
        'Conecta con la instancia de AutoCAD activa en este momento
        inicializa_conexion("2022")
        If IsNothing(DOCUMENTO) Then
            frmPrincipal.txtMensajes.Text = "Sin conexion a AutoCAD"
        Else
            frmPrincipal.txtMensajes.Text = DOCUMENTO.FullName
        End If
    End Sub

    Public Sub inicializa_conexion(ByVal versionDeAutoCAD As String)
        Dim R As String

        If versionDeAutoCAD = "2000" Then
            R = "AUTOCAD.Application.15" 'R2000-2002
        ElseIf versionDeAutoCAD = "2004" Then
            R = "AUTOCAD.Application.16" 'R2004-R2006
        ElseIf versionDeAutoCAD = "2007" Or versionDeAutoCAD = "2009" Then
            R = "AUTOCAD.Application.17" 'R2007-R2008-R2009"
        ElseIf versionDeAutoCAD = "2010" Then
            R = "AUTOCAD.Application.18" 'R2010-R2011-R2012
        ElseIf versionDeAutoCAD = "2013" Then
            R = "AUTOCAD.Application.19" 'R2013-R2014
        ElseIf versionDeAutoCAD = "2015" Then
            R = "AUTOCAD.Application.20" 'R2015-R16
        ElseIf versionDeAutoCAD = "2017" Then
            R = "AUTOCAD.Application.21" 'R2017
        ElseIf versionDeAutoCAD = "2018" Then
            R = "AUTOCAD.Application.22" 'R2018
        ElseIf versionDeAutoCAD = "2021" Or versionDeAutoCAD = "2022" Then        'R2021 R2022
            R = "AUTOCAD.Application.24"
        Else
            R = ""
        End If

        Try
            DOCUMENTO = Nothing
            AUTOCADAPP = GetObject(, R)
            DOCUMENTO = AUTOCADAPP.ActiveDocument
            UTILITY = DOCUMENTO.Utility
            AUTOCADAPP.Visible = True
        Catch er As Exception
            MsgBox(er.Message, MsgBoxStyle.Information, "CAD")
        End Try
    End Sub

    Public Sub crearLineaEnPlano()
        Dim linea As AutoCAD.AcadLine
        Dim p1(0 To 2) As Double
        Dim p2(0 To 2) As Double

        p1(0) = 0 : p1(1) = 0 : p1(2) = 100
        p2(0) = 100 : p2(1) = 1000 : p1(2) = 100

        linea = DOCUMENTO.ModelSpace.AddLine(p1, p2)
        linea.Update()

    End Sub
    'Esta funcion nos pone en pantalla AUTOCAD si esta abierto, ya que busca un proceso activo de AUTOCAD
    'Y nos ahorra el dar click en AUTOCAD o buscarlo para seleccionar el objeto
    Public Sub appActivateAutoCAD()

        'Hacemos un arreglo dinamico de los procesos activos de AUTOCAD (Aun no soluciona lo de tener mas de un proceso de AUTOCAD)
        'Detecta una proceso de AutoCAD ("ACAD") 
        Dim AUTOCADWINDNAME As String
        Dim acadProccess() As Process = Process.GetProcessesByName("ACAD")
        'Si no detecta un procesos de AUTOCAD (0) entonces manda el mensaje de error
        Try
            AUTOCADWINDNAME = acadProccess(0).MainWindowTitle
            AppActivate(AUTOCADWINDNAME)
        Catch er As Exception
            MsgBox(er.Message)
        End Try


    End Sub
    'Funcion que regresa un conjunto de seleccion de AUTOCAD
    Public Function conjunto_vacio(ByRef DOCUMENTO As AcadDocument, ByRef nombre As String) As AcadSelectionSet
        Dim indice As Integer
        nombre = nombre.Trim.ToUpper 'Los conjuntos deben ser con mayusculas
        conjunto_vacio = Nothing

        Try
            For indice = 0 To DOCUMENTO.SelectionSets.Count - 1
                If DOCUMENTO.SelectionSets.Item(indice).Name = nombre Then
                    DOCUMENTO.SelectionSets.Item(indice).Delete()
                    Exit For
                End If
            Next
            conjunto_vacio = DOCUMENTO.SelectionSets.Add(nombre)
        Catch e As ApplicationException
            MsgBox(e.Message, MsgBoxStyle.Information, "CAD")
        End Try
        Return conjunto_vacio
    End Function

    'Funcion que verifica que tiene elementos el AcadSelectionSet
    Public Function tieneElementos(ByRef conjunto As AcadSelectionSet) As Boolean
        tieneElementos = False
        'Si tiene elementos el conjunto
        Try
            If conjunto.Count > 0 Then
                tieneElementos = True 'Marca la bandera como True
            End If
        Catch e As ApplicationException
            MsgBox(e.Message, MsgBoxStyle.Information, "CAD") 'En caso de que no, manda mensaje de error
        End Try
        Return tieneElementos
    End Function
    'Funcion que toma los puntos de AutoCAD
    Public Function solicitarCoordenada(ByVal mensaje As String, Optional ByVal pb() As Double = Nothing) As Double()
        Dim p(0 To 2) As Double

        Try
            If IsNothing(pb) Then
                p = DOCUMENTO.Utility.GetPoint(, mensaje)
            Else
                p = DOCUMENTO.Utility.GetPoint(pb, mensaje) 'Si me pasas un punto yo genero el otro (Por eso nos permite el elegir linea en AutoCAD)
            End If
            Return p
        Catch e As Exception
            Return Nothing
        End Try
    End Function

    Public Function arrDinamicoCirculo(np As Integer, centro() As Double, radio As Double) As Double()
        Dim angulo As Double
        Dim deltaAng As Double = (3.1416 * 360 / np) / 180
        Dim coords() As Double
        Dim i As Integer
        Dim ind As Integer = 0
        Dim p() As Double

        ReDim coords(3 * np - 1)
        angulo = 0
        For i = 1 To np
            p = DOCUMENTO.Utility.PolarPoint(centro, angulo, radio)
            coords(ind) = p(0) : coords(ind + 1) = p(1) : coords(ind + 2) = p(2)
            angulo = angulo + deltaAng
            ind = ind + 3
        Next
        Return coords
    End Function


    Public Function obtenerDistancia(ByVal p1() As Double, ByVal p2() As Double) As Double
        Dim distancia As Double

        distancia = Math.Sqrt(Math.Pow(p2(0) - p1(0), 2) + Math.Pow(p2(1) - p1(1), 2) + Math.Pow(p2(2) - p1(2), 2))

        Return distancia
    End Function


    'Seleccion de objetos
    'Primero debo conectarme a AutoCAD y luego seleccionar la opcion de un solo objeto en el Form
    Public Sub seleccionObjetos(metodo As String)

        Dim conjunto As AcadSelectionSet 'Conjunto de seleccion de AUTOCAD
        Dim entidad As AcadEntity = Nothing 'Entidad de AUTOCAD
        Dim esquinas(11) As Double
        Dim p(0 To 2) As Double
        Dim p1(0 To 2) As Double

        Dim radio As Double
        Dim coordCirculo() As Double

        appActivateAutoCAD()

        Select Case metodo
            'Seleccion selectiva del plano
            Case "A"
                conjunto = conjunto_vacio(DOCUMENTO, "IDLE") 'Inicializa el objeto
                If Not IsNothing(conjunto) Then 'Si no es nulo
                    conjunto.SelectOnScreen() 'Toma lo seleccionado en la pantalla
                    If tieneElementos(conjunto) Then
                        MsgBox(conjunto.Count)
                    Else
                        MsgBox("No hay elementos en el conjunto")
                    End If
                End If
            'Seleccion en un rectangulo
            Case "B"
                p = solicitarCoordenada("Esquina 1")
                If Not IsNothing(p) Then
                    p1 = solicitarCoordenada("Esquina opuesta", p)
                    If Not IsNothing(p1) Then
                        'Cada tres indices representa coordenadas en XYZ
                        esquinas(0) = p(0) : esquinas(1) = p(1) : esquinas(2) = 0 'Coordenada 1
                        esquinas(3) = p1(0) : esquinas(4) = p(1) : esquinas(5) = 0 'Coordenada 2
                        esquinas(6) = p1(0) : esquinas(7) = p1(1) : esquinas(8) = 0 'Coordenada 3
                        esquinas(9) = p(0) : esquinas(10) = p1(1) : esquinas(11) = 0 'Coordenada 4
                        conjunto = conjunto_vacio(DOCUMENTO, "IDLE")
                        If Not IsNothing(conjunto) Then
                            conjunto.SelectByPolygon(AcSelect.acSelectionSetCrossingPolygon, esquinas)
                            MsgBox(conjunto.Count)
                        End If
                    End If
                End If
            'Selecciona Todo
            Case "C"
                conjunto = conjunto_vacio(DOCUMENTO, "IDLE")
                If Not IsNothing(conjunto) Then
                    conjunto.Select(AcSelect.acSelectionSetAll)
                    MsgBox(conjunto.Count)
                End If

            'Seleccion de un solo objeto
            Case "D"
                Try
                    DOCUMENTO.Utility.GetEntity(entidad, p, "Selecciona una entidad")
                Catch
                    entidad = Nothing
                End Try
                If Not IsNothing(entidad) Then
                    MsgBox(entidad.ObjectName)
                End If

            'Seleccion circulo
            Case "E"
                p = solicitarCoordenada("Centro")
                If Not IsNothing(p) Then
                    p1 = solicitarCoordenada("Indica el Radio", p)
                    If Not IsNothing(p1) Then
                        radio = obtenerDistancia(p, p1)
                        coordCirculo = arrDinamicoCirculo(10, p, radio)
                        conjunto = conjunto_vacio(DOCUMENTO, "IDLE")
                        If Not IsNothing(conjunto) Then
                            conjunto.SelectByPolygon(AcSelect.acSelectionSetCrossingPolygon, coordCirculo)
                            MsgBox(conjunto.Count)
                        End If
                        'graficaPol(coordCirculo, True)
                    End If
                End If

        End Select



    End Sub
    'Selecciona todo el plano y cuenta cuantas lineas, circulos y otras cosas
    Public Sub analizaSeleccion(tipo As String)
        Dim conjunto As AcadSelectionSet
        Dim elemento As AcadEntity
        Dim numcircles As Integer = 0
        Dim numlineas As Integer = 0
        Dim numOtros As Integer = 0
        Dim tipoEntidad As String

        Select Case tipo
            Case "Clasifica por tipo"
                conjunto = conjunto_vacio(DOCUMENTO, "IDLE")
                If Not IsNothing(conjunto) Then
                    conjunto.Select(AcSelect.acSelectionSetAll)
                    For Each elemento In conjunto
                        tipoEntidad = elemento.ObjectName
                        Select Case tipoEntidad
                            Case "AcDbCircle"
                                numcircles = numcircles + 1
                            Case "AcDbLine"
                                numlineas = numlineas + 1
                            Case Else
                                numOtros = numOtros + 1
                        End Select
                    Next
                    MsgBox("Lineas = " & numlineas & " Circulos = " & numcircles & " Otras = " & numOtros)
                End If
        End Select
    End Sub

    '' Diccionarios
    'Public Sub addXdata(ByRef entidad As AcadEntity, nameXrecord As String, valor As String)
    '    'Agrega un Xrecord y un solo valor 
    '    Dim dictASTI As AcadDictionary
    '    Dim astiXRec As AcadXRecord
    '    Dim keyCode() As Short 'OBLIGATORIO QUE SEA SHORT. INTEGER ENVIA ERROR EN EL SETXRECORDDATA
    '    Dim cptData() As Object 'OBLIGATORIO OBJECT
    '    ReDim keyCode(0)
    '    ReDim cptData(0)
    '    dictASTI = entidad.GetExtensionDictionary
    '    astiXRec = dictASTI.AddXRecord(nameXrecord.ToUpper.Trim)
    '    keyCode(0) = 100 : cptData(0) = valor
    '    astiXRec.SetXRecordData(keyCode, cptData)
    'End Sub

    'Public Sub agregarDatoAUnElemento()
    '    'ejemplo de agregacion de un dato a un elemento
    '    'Vamos a agregar el TIPO de elemento AUTO SEMAFORO o VIALIDAD a un objeto
    '    Dim p() As Double
    '    Dim entidad As AcadEntity
    '    Dim tipoObjeto As String
    '    appActivateAutoCAD()
    '    'Seleccionando el valor del TIPO que vamos a asignar
    '    tipoObjeto = frmPrincipal.listaDeObjetos.SelectedItem
    '    entidad = getEntidadGenerica(p, "Selecciona una entidad ")
    '    'Agregando el registro TIPO con su valor tipoObjeto
    '    addXdata(entidad, "TIPO", tipoObjeto)
    'End Sub

    'Public Sub recuperarUnDatoDeUnElemento()
    '    'recuperar el dato de un elemento desde un diccionario
    '    Dim p() As Double
    '    Dim entidad As AcadEntity
    '    Dim tipoObjeto As String
    '    appActivateAutoCAD()
    '    entidad = getEntidadGenerica(p, "Selecciona una entidad ")
    '    If entidad Is Nothing Then
    '    Else
    '        getXdata(entidad, "TIPO", tipoObjeto)
    '        DOCUMENTO.Utility.Prompt("El tipo del dato es: " & tipoObjeto)
    '    End If
    'End Sub

    'Public Sub getXdata(entidad As AcadEntity, nameXrecord As String, ByRef valor As String)
    '    'extrayendo datos
    '    'estamos considerando que un Xrecrd solo tiene un dato lo cual no es asi porque puede tener muchos datos
    '    Dim astiXRec As AcadXRecord = Nothing
    '    Dim dictASTI As AcadDictionary
    '    Dim getKey As Object = Nothing
    '    Dim getData As Object = Nothing
    '    valor = Nothing
    '    dictASTI = entidad.GetExtensionDictionary
    '    Try
    '        astiXRec = dictASTI.Item(nameXrecord.ToUpper.Trim) 'revisando si existe el Xrecord
    '    Catch ex As System.Runtime.InteropServices.COMException
    '        'no exite el Xrecord con la entrada nameXrecord lo cual causa la excepcion
    '        'Esta forma de manejar una excepcion si funciono y debe complementarse al momento de 
    '        'recibir el mensaje de excepciones que se produzcan y palomear el nombre de la aplicacion
    '        'para que no se detenga la ejecucion en este programa
    '    End Try
    '    If Not IsNothing(astiXRec) Then
    '        astiXRec.GetXRecordData(getKey, getData)
    '        If Not IsNothing(getData) Then
    '            valor = getData(0) 'recuperando el valor del XRecord
    '        End If
    '    End If
    'End Sub

    'Public Function getEntidadGenerica(ByRef p() As Double, mensaje As String) As AcadEntity
    '    Dim entidadGenerica As AcadEntity = Nothing
    '    Try
    '        DOCUMENTO.Utility.GetEntity(entidadGenerica, p, mensaje)
    '    Catch
    '        p = Nothing
    '    End Try
    '    Return entidadGenerica
    'End Function

End Module
