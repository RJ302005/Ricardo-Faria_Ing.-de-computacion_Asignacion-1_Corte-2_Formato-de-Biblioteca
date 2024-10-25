Public Class BibliotecaForm
    ' Lista de libros
    Private ListaLibros As New List(Of Libro)

    ' Evento que se ejecuta cuando el formulario carga
    Private Sub BibliotecaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llenar ComboBox con opciones
        cmbOperaciones.Items.Add("Agregar Libro")
        cmbOperaciones.Items.Add("Modificar Libro")
        cmbOperaciones.Items.Add("Eliminar Libro")
        cmbOperaciones.Items.Add("Prestar Libro")
        cmbOperaciones.Items.Add("Devolver Libro")
        cmbOperaciones.SelectedIndex = 0 ' Selecciona la primera opción por defecto
    End Sub

    ' Método que se ejecuta cuando se presiona el botón "Ejecutar"
    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        ' Obtener la operación seleccionada en el ComboBox
        Dim operacionSeleccionada As String = cmbOperaciones.SelectedItem.ToString()

        Select Case operacionSeleccionada
            Case "Agregar Libro"
                ' Llamar al método para agregar un libro
                AgregarLibro()

            Case "Modificar Libro"
                ' Llamar al método para modificar un libro
                ModificarLibro()

            Case "Eliminar Libro"
                ' Llamar al método para eliminar un libro
                EliminarLibro()

            Case "Prestar Libro"
                ' Llamar al método para prestar un libro
                PrestarLibro()

            Case "Devolver Libro"
                ' Llamar al método para devolver un libro
                DevolverLibro()

            Case Else
                MessageBox.Show("Seleccione una operación válida")
        End Select
    End Sub

    ' Métodos para las operaciones en la biblioteca

    ' Método para agregar un libro
    Private Sub AgregarLibro()
        Dim nuevoLibro As New Libro(TXTTitulo.Text, TXTAUTOR.Text, TXTEditorial.Text)
        ListaLibros.Add(nuevoLibro)
        ActualizarListaLibros()
        MessageBox.Show("Libro agregado exitosamente")
    End Sub

    ' Método para modificar un libro
    Private Sub ModificarLibro()
        Dim libroSeleccionado As Libro = ObtenerLibroSeleccionado()
        If libroSeleccionado IsNot Nothing Then
            libroSeleccionado.Titulo = TXTTitulo.Text
            libroSeleccionado.Autor = TXTAUTOR.Text
            libroSeleccionado.Editorial = TXTEditorial.Text
            ActualizarListaLibros()
            MessageBox.Show("Libro modificado exitosamente")
        Else
            MessageBox.Show("Seleccione un libro primero")
        End If
    End Sub

    ' Método para eliminar un libro
    Private Sub EliminarLibro()
        Dim libroSeleccionado As Libro = ObtenerLibroSeleccionado()
        If libroSeleccionado IsNot Nothing Then
            ListaLibros.Remove(libroSeleccionado)
            ActualizarListaLibros()
            MessageBox.Show("Libro eliminado exitosamente")
        Else
            MessageBox.Show("Seleccione un libro primero")
        End If
    End Sub

    ' Método para prestar un libro
    Private Sub PrestarLibro()
        Dim libroSeleccionado As Libro = ObtenerLibroSeleccionado()
        If libroSeleccionado IsNot Nothing Then
            If libroSeleccionado.PrestarLibro() Then
                MessageBox.Show("Libro prestado exitosamente")
            Else
                MessageBox.Show("El libro ya está prestado")
            End If
        Else
            MessageBox.Show("Seleccione un libro primero")
        End If
    End Sub

    ' Método para devolver un libro
    Private Sub DevolverLibro()
        Dim libroSeleccionado As Libro = ObtenerLibroSeleccionado()
        If libroSeleccionado IsNot Nothing Then
            If libroSeleccionado.DevolverLibro() Then
                MessageBox.Show("Libro devuelto exitosamente")
            Else
                MessageBox.Show("El libro no estaba prestado")
            End If
        Else
            MessageBox.Show("Seleccione un libro primero")
        End If
    End Sub

    ' Método para obtener el libro seleccionado en la lista
    Private Function ObtenerLibroSeleccionado() As Libro
        If lstLibros.SelectedIndex >= 0 Then
            Return ListaLibros(lstLibros.SelectedIndex)
        Else
            Return Nothing
        End If
    End Function

    ' Método para actualizar la lista de libros en la interfaz
    Private Sub ActualizarListaLibros()
        lstLibros.Items.Clear()
        For Each libro In ListaLibros
            lstLibros.Items.Add(libro.Titulo & " - " & If(libro.Disponible, "Disponible", "Prestado"))
        Next
    End Sub

    ' Evento para seleccionar un libro y mostrar los datos en los campos
    Private Sub lstLibros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLibros.SelectedIndexChanged
        Dim libroSeleccionado As Libro = ObtenerLibroSeleccionado()
        If libroSeleccionado IsNot Nothing Then
            TXTTitulo.Text = libroSeleccionado.Titulo
            TXTAUTOR.Text = libroSeleccionado.Autor
            TXTEditorial.Text = libroSeleccionado.Editorial
        End If
    End Sub
End Class
