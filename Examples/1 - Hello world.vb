Imports Salem
Imports System

Module Program
	Sub Main(args As String())
		Dim	logger As New Logger()
		logger.Log("Info", "Hello World!")
		Console.ReadKey()
	End Sub
End Module
