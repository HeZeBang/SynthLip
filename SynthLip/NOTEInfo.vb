Public Class NOTEInfo
    Private ReadOnly NoteBasic As New Dictionary(Of String, String)
    Private phn() As String
    Private scl() As Double
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

    Public Property Phonemes As String
        Set(value As String)
            NoteBasic.Add(“phn", value)
            phn = value.Split(",")
        End Set
        Get
            Return NoteBasic.Item("phn")
        End Get
    End Property

    Public Property Scales As String
        Set(value As String)
            NoteBasic.Add(“scl", value)
            Dim cnt As Integer = 1
            For Each i In value.Split(",")
                scl(cnt) = Val(i)
                cnt += 1
            Next
        End Set
        Get
            Return NoteBasic.Item("scl")
        End Get
    End Property
    Public Function GetScale() As Array
        Return scl
    End Function
    Public Function GetPhonemes() As Array
        Return phn
    End Function
    Public Function SetVal(ByVal p As String, ByVal val As Object) As Boolean
        NoteBasic.Add(p, val)
        Return True
    End Function
    Public Function GetVal(ByVal p As String) As String
        Return NoteBasic.Item(p)
    End Function
End Class
