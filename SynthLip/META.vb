Public Class META
    Private ReadOnly Dic As New Dictionary(Of String, Object)
    Public Property PrjName As String
        Set(value As String)
            Dic.Add("PrjName", value)
        End Set
        Get
            Return Dic.Item("PrjName")
        End Get
    End Property
    Public Property PrjPath As String
        Set(value As String)
            Dic.Add("PrjPath", value)
        End Set
        Get
            Return Dic.Item("PrjPath")
        End Get
    End Property
    Public Property EditTime As Long
        Set(value As Long)
            Dic.Add("EditTime", value)
        End Set
        Get
            Return Dic.Item("EditTime")
        End Get
    End Property
    Public Property ScriptVersion As String
        Set(value As String)
            Dic.Add("ScriptVersion", value)
        End Set
        Get
            Return Dic.Item("ScriptVersion")
        End Get
    End Property
    Public Property NoteCount As String
        Set(value As String)
            Dic.Add("NoteCount", value)
        End Set
        Get
            Return Dic.Item("NoteCount")
        End Get
    End Property
    Public Property Track As String
        Set(value As String)
            Dic.Add("Track", value)
        End Set
        Get
            Return Dic.Item("Track")
        End Get
    End Property
    Public Property TrackName As String
        Set(value As String)
            Dic.Add("TrackName", value)
        End Set
        Get
            Return Dic.Item("TrackName")
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
