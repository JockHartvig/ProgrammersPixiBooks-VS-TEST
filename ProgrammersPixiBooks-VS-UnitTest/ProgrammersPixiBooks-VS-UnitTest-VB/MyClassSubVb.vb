Imports ProgrammersPixiBooks_VS_UnitTest_VB

Public Interface IMySubClassVb
    Property VarStringMySubClass As String

End Interface

Public Class MySubClassVb
    Implements IMySubClassVb

    Public Property VarStringMySubClass As String = "From MySubClassVb" Implements IMySubClassVb.VarStringMySubClass

End Class
