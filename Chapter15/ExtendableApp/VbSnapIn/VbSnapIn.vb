Imports CommonSnappableTypes

<CompanyInfo(CompanyName:="Chucky's Software", CompanyUrl:="www.ChuckySoft.com")>
Public Class VbModule
    Implements IAppFunctionality
    Public Sub DoIt() Implements IAppFunctionality.DoIt
        Console.WriteLine("Вы только что использовали оснастку Visual Basic!")
    End Sub
End Class
