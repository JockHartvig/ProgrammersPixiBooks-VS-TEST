Public Class MyClassVb

    '------------------------
    '  Public Properties
    '------------------------
    Public VarStringMyClassVb As String

    '------------------------
    '  Private Properties
    '------------------------

    Private _IMySubClass As IMySubClassVb = New MySubClassVb()

    '------------------------
    '  Class Constructors
    '------------------------
    Public Sub New()

    End Sub

    ' Dependency Injection of MySubClass by Constructor
    Public Sub New(pMySubClass As IMySubClassVb)
        _IMySubClass = pMySubClass
    End Sub

    '------------------------
    '  Class Public Methods
    '------------------------

    ' Dependency Injection of MySubClass by setter function
    Public Sub SetIMyClassSub(pMySubClass As IMySubClassVb)
        _IMySubClass = pMySubClass
    End Sub



    Public Function CallMySubClass() As String

        Return (_IMySubClass.VarStringMySubClass)

    End Function

End Class
