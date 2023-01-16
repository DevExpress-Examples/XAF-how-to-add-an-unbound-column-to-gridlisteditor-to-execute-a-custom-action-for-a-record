Imports System
Imports System.Configuration
Imports System.Windows.Forms
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports WinSolution.Module

Namespace WinSolution.Win

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            FrameworkSettings.DefaultSettingsCompatibilityMode = FrameworkSettingsCompatibilityMode.v20_1
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
            Dim winApplication As WinSolutionWindowsFormsApplication = New WinSolutionWindowsFormsApplication()
            winApplication.ConnectionString = CodeCentralExampleInMemoryDataStoreProvider.ConnectionString
            If ConfigurationManager.ConnectionStrings("ConnectionString") IsNot Nothing Then
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            End If

            Try
                Xpo.InMemoryDataStoreProvider.Register()
                winApplication.ConnectionString = Xpo.InMemoryDataStoreProvider.ConnectionString
                winApplication.Setup()
                winApplication.Start()
            Catch e As Exception
                winApplication.HandleException(e)
            End Try
        End Sub
    End Module
End Namespace
