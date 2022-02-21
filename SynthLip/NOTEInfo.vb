Public Class NOTEInfo
    Private ReadOnly NoteBasic As Dictionary(Of String, String)

    Public Property Lyric As String
        Set(value As String)
            NoteBasic.Add(“lrc", value)
        End Set
        Get
            Return NoteBasic.Item("lrc")
        End Get
    End Property
    Public Property Onset As String
        Set(value As String)
            NoteBasic.Add(“ons", value)
        End Set
        Get
            Return NoteBasic.Item("ons")
        End Get
    End Property
    Public Property Duration As String
        Set(value As String)
            NoteBasic.Add(“dur", value)
        End Set
        Get
            Return NoteBasic.Item("dur")
        End Get
    End Property
    Public Property NumofPhn As String
        Set(value As String)
            NoteBasic.Add(“num", value)
        End Set
        Get
            Return NoteBasic.Item("num")
        End Get
    End Property
    Public Property Pitch As String
        Set(value As String)
            NoteBasic.Add(“pit", value)
        End Set
        Get
            Return NoteBasic.Item("pit")
        End Get
    End Property

    Private phn As Array
    Public Property Phonemes() As Array
        Set(value As Array)
            phn = value.Clone
        End Set
        Get
            Return phn
        End Get
    End Property

    Private scl As Array
    Public Property Scales() As Array
        Set(value As Array)
            scl = value.Clone
        End Set
        Get
            Return scl
        End Get
    End Property
    Public Function SetVal(ByVal p As String, ByVal val As Object) As Boolean
        If p = "scl" Then
            For Each i In val.ToString.Split(",")
                scl(scl.Length) = i
            Next
        ElseIf p = "phn" Then
            For Each i In val.ToString.Split(",")
                scl(scl.Length) = i
            Next
        Else
            NoteBasic.Add(p, val)
            Debug.Print(p & val)
        End If
        Return True
    End Function
    Public Function GetVal(ByVal p As String) As String
        Return NoteBasic.Item(p)
    End Function
End Class
