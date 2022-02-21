Public Class host
    Dim name, path, ver As String
    Dim time As Long
    Dim index As Integer
    Dim Dic As New Dictionary(Of String, Object)
    Public Property PrjName As String
        Set(value As String)
            Dic.Add("PrjName", value)
        End Set
        Get
            Return name
        End Get
    End Property
    Public Property PrjPath As String
        Set(value As String)
            Dic.Add("PrjPath", value)
        End Set
        Get
            Return path
        End Get
    End Property
    Public Property EditTime As Long
        Set(value As Long)
            Dic.Add("EditTime", value)
        End Set
        Get
            Return time
        End Get
    End Property
    Public Property ScriptVersion As String
        Set(value As String)
            Dic.Add("ScriptVersion", value)
        End Set
        Get
            Return ver
        End Get
    End Property
    Public Property NoteCount As String
        Set(value As String)
            Dic.Add("NoteCount", value)
        End Set
        Get
            Return index
        End Get
    End Property
    Public Function SetVal(ByVal p As String, ByVal val As Object) As Boolean
        Dic.Add(p, val)
        Return True
    End Function
    Public Function GetVal(ByVal p As String) As String
        Return Dic.Item(p)
    End Function
End Class
