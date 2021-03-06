﻿Public Class Frm_ListaFlotas

    Private Sub PierdeFoco(ByVal sender As TextBox, ByVal e As System.EventArgs) Handles cmbEstado.LostFocus, txt_buscar.LostFocus
        sender.BackColor = Color.White
        sender.SelectAll()
    End Sub
    Sub CargarGrid(ByVal Estado As Boolean, ByVal Nombre As String)
        Dim TablaFlota As New DataTable
        Dim Flo As New LCN.Flota

        TablaFlota = Flo.Obtener(Nombre, Estado)


        If Not IsNothing(TablaFlota) Then
            Me.dgFlotas.DataSource = TablaFlota
        Else
            For i As Integer = 0 To Me.dgFlotas.Rows.Count - 1
                Me.dgFlotas.Rows.RemoveAt(0)
            Next
        End If
        Me.dgFlotas.ClearSelection()
    End Sub

    Private Sub AgarraFoco(ByVal sender As TextBox, ByVal e As System.EventArgs) Handles cmbEstado.GotFocus, txt_buscar.GotFocus
        sender.BackColor = Color.LightCyan
        sender.SelectAll()
    End Sub
    Private Sub dgFlotas_MouseDown(sender As Object, e As MouseEventArgs) Handles dgFlotas.MouseDown
        If e.Button = MouseButtons.Right Then
            With Me.dgFlotas
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    .ContextMenuStrip = Me.ContextMenuStrip1
                End If
            End With
        Else
            Me.dgFlotas.ContextMenuStrip = Nothing
        End If
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub Frm_ListaFlotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmbEstado.SelectedIndex = 1
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        Me.CargarGrid(Me.cmbEstado.SelectedIndex, Me.txt_buscar.Text)
    End Sub

    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        Me.CargarGrid(Me.cmbEstado.SelectedIndex, Me.txt_buscar.Text)
    End Sub
End Class