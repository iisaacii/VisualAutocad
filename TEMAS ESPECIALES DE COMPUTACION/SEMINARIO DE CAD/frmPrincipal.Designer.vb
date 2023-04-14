<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdministracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConectarConAutoCADToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EjemplosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearUnaLineaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnObjetoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionSelectivaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementosEnUnRectanguloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementosEnUnCirculoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContandoLineasYCirculosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtMensajes = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdministracionToolStripMenuItem, Me.EjemplosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(600, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdministracionToolStripMenuItem
        '
        Me.AdministracionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConectarConAutoCADToolStripMenuItem})
        Me.AdministracionToolStripMenuItem.Name = "AdministracionToolStripMenuItem"
        Me.AdministracionToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.AdministracionToolStripMenuItem.Text = "Administracion"
        '
        'ConectarConAutoCADToolStripMenuItem
        '
        Me.ConectarConAutoCADToolStripMenuItem.Name = "ConectarConAutoCADToolStripMenuItem"
        Me.ConectarConAutoCADToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ConectarConAutoCADToolStripMenuItem.Text = "Conectar con AutoCAD"
        '
        'EjemplosToolStripMenuItem
        '
        Me.EjemplosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrearUnaLineaToolStripMenuItem, Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem})
        Me.EjemplosToolStripMenuItem.Name = "EjemplosToolStripMenuItem"
        Me.EjemplosToolStripMenuItem.Size = New System.Drawing.Size(67, 22)
        Me.EjemplosToolStripMenuItem.Text = "Ejemplos"
        '
        'CrearUnaLineaToolStripMenuItem
        '
        Me.CrearUnaLineaToolStripMenuItem.Name = "CrearUnaLineaToolStripMenuItem"
        Me.CrearUnaLineaToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.CrearUnaLineaToolStripMenuItem.Text = "Crear una linea"
        '
        'SeleccionDeObjetosEnElPlanoToolStripMenuItem
        '
        Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnObjetoToolStripMenuItem, Me.SeleccionSelectivaToolStripMenuItem, Me.ElementosEnUnRectanguloToolStripMenuItem, Me.ElementosEnUnCirculoToolStripMenuItem, Me.TodoToolStripMenuItem, Me.ContandoLineasYCirculosToolStripMenuItem})
        Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem.Name = "SeleccionDeObjetosEnElPlanoToolStripMenuItem"
        Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem.Text = "Seleccion de objetos en el plano"
        '
        'UnObjetoToolStripMenuItem
        '
        Me.UnObjetoToolStripMenuItem.Name = "UnObjetoToolStripMenuItem"
        Me.UnObjetoToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.UnObjetoToolStripMenuItem.Text = "Un Objeto"
        '
        'SeleccionSelectivaToolStripMenuItem
        '
        Me.SeleccionSelectivaToolStripMenuItem.Name = "SeleccionSelectivaToolStripMenuItem"
        Me.SeleccionSelectivaToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.SeleccionSelectivaToolStripMenuItem.Text = "Seleccion Selectiva"
        '
        'ElementosEnUnRectanguloToolStripMenuItem
        '
        Me.ElementosEnUnRectanguloToolStripMenuItem.Name = "ElementosEnUnRectanguloToolStripMenuItem"
        Me.ElementosEnUnRectanguloToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ElementosEnUnRectanguloToolStripMenuItem.Text = "Elementos en un Rectangulo"
        '
        'ElementosEnUnCirculoToolStripMenuItem
        '
        Me.ElementosEnUnCirculoToolStripMenuItem.Name = "ElementosEnUnCirculoToolStripMenuItem"
        Me.ElementosEnUnCirculoToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ElementosEnUnCirculoToolStripMenuItem.Text = "Elementos en un circulo"
        '
        'TodoToolStripMenuItem
        '
        Me.TodoToolStripMenuItem.Name = "TodoToolStripMenuItem"
        Me.TodoToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.TodoToolStripMenuItem.Text = "Todo"
        '
        'ContandoLineasYCirculosToolStripMenuItem
        '
        Me.ContandoLineasYCirculosToolStripMenuItem.Name = "ContandoLineasYCirculosToolStripMenuItem"
        Me.ContandoLineasYCirculosToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ContandoLineasYCirculosToolStripMenuItem.Text = "Contando Lineas y Circulos"
        '
        'txtMensajes
        '
        Me.txtMensajes.Location = New System.Drawing.Point(9, 331)
        Me.txtMensajes.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtMensajes.Name = "txtMensajes"
        Me.txtMensajes.Size = New System.Drawing.Size(558, 20)
        Me.txtMensajes.TabIndex = 1
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 365)
        Me.Controls.Add(Me.txtMensajes)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "frmPrincipal"
        Me.Text = "Principal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AdministracionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConectarConAutoCADToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtMensajes As TextBox
    Friend WithEvents EjemplosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrearUnaLineaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeleccionDeObjetosEnElPlanoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnObjetoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeleccionSelectivaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ElementosEnUnRectanguloToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ElementosEnUnCirculoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TodoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContandoLineasYCirculosToolStripMenuItem As ToolStripMenuItem
End Class
