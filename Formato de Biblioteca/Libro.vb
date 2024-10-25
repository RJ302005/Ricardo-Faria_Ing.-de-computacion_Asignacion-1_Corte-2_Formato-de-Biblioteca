Public Class Libro
    ' Atributos (con Property)
    Public Property Titulo As String
    Public Property Autor As String
    Public Property Editorial As String
    Public Property Disponible As Boolean = True ' Para verificar si está disponible

    ' Constructor
    Public Sub New(titulo As String, autor As String, editorial As String)
        Me.Titulo = titulo
        Me.Autor = autor
        Me.Editorial = editorial
    End Sub

    ' Método para prestar un libro
    Public Function PrestarLibro() As Boolean
        If Disponible Then
            Disponible = False
            Return True ' Indica que el libro fue prestado exitosamente
        Else
            Return False ' No se puede prestar porque ya está prestado
        End If
    End Function

    ' Método para devolver un libro
    Public Function DevolverLibro() As Boolean
        If Not Disponible Then
            Disponible = True
            Return True ' Indica que el libro fue devuelto exitosamente
        Else
            Return False ' No se puede devolver porque no estaba prestado
        End If
    End Function
End Class
