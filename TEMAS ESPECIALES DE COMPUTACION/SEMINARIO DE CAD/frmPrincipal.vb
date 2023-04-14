Public Class frmPrincipal
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    'Evento para conectarse a AUTOCAD con el formulario
    Private Sub ConectarConAutoCADToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConectarConAutoCADToolStripMenuItem.Click
        ConectarConAutoCAD
    End Sub

    Private Sub CrearUnaLineaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearUnaLineaToolStripMenuItem.Click
        crearLineaEnPlano
    End Sub
    'Evento para seleccionar un objeto con el formulario
    Private Sub UnObjetoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnObjetoToolStripMenuItem.Click
        Me.Visible = False
        seleccionObjetos("D")
        Me.Visible = True
    End Sub
    'Evento para seleccionar varios objetos con e formulario
    Private Sub SeleccionSelectivaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionSelectivaToolStripMenuItem.Click
        Me.Visible = False
        seleccionObjetos("A")
        Me.Visible = True
    End Sub

    Private Sub ElementosEnUnRectanguloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElementosEnUnRectanguloToolStripMenuItem.Click
        Me.Visible = False
        seleccionObjetos("B")
        Me.Visible = True
    End Sub

    Private Sub TodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TodoToolStripMenuItem.Click
        Me.Visible = False
        seleccionObjetos("C")
        Me.Visible = True
    End Sub

    Private Sub ContandoLineasYCirculosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContandoLineasYCirculosToolStripMenuItem.Click
        analizaSeleccion("Clasifica por tipo")
    End Sub

    Private Sub ElementosEnUnCirculoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElementosEnUnCirculoToolStripMenuItem.Click
        Me.Visible = False
        seleccionObjetos("E")
        Me.Visible = True
    End Sub
End Class
