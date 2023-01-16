Imports System
Imports DevExpress.Data
Imports DevExpress.Utils
Imports DevExpress.ExpressApp
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.ExpressApp.Win.Editors

Namespace WinSolution.Module.Win

    Public Class SimpleBusinessActionGridListViewController
        Inherits ViewController(Of ListView)

        Private unboundModelColumn As IModelColumn

        Private Const ButtonColumnCaption As String = "Action"

        Private Const ButtonColumnName As String = "UnboundButtonColumn"

        Private activeRepositoryItemButtonEdit, inactiveRepositoryItemButtonEdit As RepositoryItemButtonEdit

        Private activebutton As EditorButton = New EditorButton(ButtonPredefines.OK)

        Private inactivebutton As EditorButton = New EditorButton(ButtonPredefines.Close)

        Private gridListEditor As GridListEditor

        Public Sub New()
            TargetObjectType = GetType(Order)
        End Sub

        Protected Overrides Sub OnViewControlsCreated()
            MyBase.OnViewControlsCreated()
            gridListEditor = TryCast(View.Editor, GridListEditor)
            If gridListEditor IsNot Nothing Then
                InitGridView()
                InitButtonColumn()
            End If
        End Sub

        Private Sub InitGridView()
            AddHandler gridListEditor.GridView.CustomRowCellEdit, AddressOf gridView_CustomRowCellEdit
            AddHandler gridListEditor.GridView.CustomRowCellEditForEditing, AddressOf gridView_CustomRowCellEdit
            gridListEditor.GridView.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDown
        End Sub

        Private Sub InitButtonColumn()
            unboundModelColumn = TryCast(CType(gridListEditor.Model.Columns, IModelColumns).GetNode(ButtonColumnName), IModelColumn)
            If unboundModelColumn Is Nothing Then
                unboundModelColumn = gridListEditor.Model.Columns.AddNode(Of IModelColumn)(ButtonColumnName)
                unboundModelColumn.PropertyName = ButtonColumnName
                unboundModelColumn.Width = 50
                unboundModelColumn.PropertyEditorType = GetType(DefaultPropertyEditor)
                For i As Integer = gridListEditor.Columns.Count - 1 To 0 Step -1
                    Dim cw As ColumnWrapper = gridListEditor.Columns(i)
                    If Equals(cw.PropertyName, unboundModelColumn.PropertyName) Then
                        gridListEditor.RemoveColumn(cw)
                        Exit For
                    End If
                Next

                gridListEditor.AddColumn(unboundModelColumn)
            End If

            Dim buttonColumn As GridColumn = gridListEditor.GridView.Columns(unboundModelColumn.PropertyName)
            If buttonColumn IsNot Nothing Then
                buttonColumn.UnboundType = UnboundColumnType.Boolean
                buttonColumn.Caption = ButtonColumnCaption
                buttonColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                buttonColumn.VisibleIndex = 0
                buttonColumn.OptionsColumn.AllowEdit = True
                buttonColumn.OptionsColumn.AllowGroup = DefaultBoolean.False
                buttonColumn.OptionsColumn.AllowMove = False
                buttonColumn.OptionsColumn.AllowShowHide = False
                buttonColumn.OptionsColumn.AllowSize = False
                buttonColumn.OptionsColumn.AllowSort = DefaultBoolean.False
                buttonColumn.OptionsColumn.FixedWidth = True
                buttonColumn.OptionsColumn.ShowInCustomizationForm = False
                buttonColumn.OptionsFilter.AllowFilter = False
                InitButtonEditor(activeRepositoryItemButtonEdit, True)
                InitButtonEditor(inactiveRepositoryItemButtonEdit, False)
            End If
        End Sub

        Private Sub InitButtonEditor(ByRef properties As RepositoryItemButtonEdit, ByVal active As Boolean)
            properties = New RepositoryItemButtonEdit()
            properties.TextEditStyle = TextEditStyles.HideTextEditor
            AddHandler properties.Click, AddressOf buttonColumnColumnProperties_Click
            UpdateButtons(properties, active)
            gridListEditor.Grid.RepositoryItems.Add(properties)
        End Sub

        Private Sub UpdateButtons(ByVal properties As RepositoryItemButtonEdit, ByVal active As Boolean)
            Dim button As EditorButton = If(active, inactivebutton, activebutton)
            If properties.Buttons(0).Kind <> button.Kind Then
                properties.BeginInit()
                properties.Buttons.Clear()
                properties.Buttons.Add(button)
                properties.EndInit()
            End If
        End Sub

        Private Sub gridView_CustomRowCellEdit(ByVal sender As Object, ByVal e As CustomRowCellEditEventArgs)
            If Equals(e.Column.FieldName, ButtonColumnName) Then
                Dim order As ISimpleBusinessAction = TryCast(gridListEditor.GridView.GetRow(e.RowHandle), ISimpleBusinessAction)
                If order IsNot Nothing Then
                    e.RepositoryItem = If(order.Active, activeRepositoryItemButtonEdit, inactiveRepositoryItemButtonEdit)
                End If
            End If
        End Sub

        Private Sub buttonColumnColumnProperties_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim editor As ButtonEdit = CType(sender, ButtonEdit)
            Dim order As ISimpleBusinessAction = TryCast(gridListEditor.GridView.GetFocusedRow(), ISimpleBusinessAction)
            If order IsNot Nothing Then
                order.SimpleBusinessAction()
                UpdateButtons(editor.Properties, order.Active)
            End If
        End Sub

        Protected Overrides Sub OnDeactivated()
            If gridListEditor IsNot Nothing AndAlso gridListEditor.GridView IsNot Nothing Then
                RemoveHandler gridListEditor.GridView.CustomRowCellEdit, AddressOf gridView_CustomRowCellEdit
                RemoveHandler gridListEditor.GridView.CustomRowCellEditForEditing, AddressOf gridView_CustomRowCellEdit
                If unboundModelColumn IsNot Nothing Then unboundModelColumn.Remove()
            End If

            If activeRepositoryItemButtonEdit IsNot Nothing Then RemoveHandler activeRepositoryItemButtonEdit.Click, AddressOf buttonColumnColumnProperties_Click
            If inactiveRepositoryItemButtonEdit IsNot Nothing Then RemoveHandler inactiveRepositoryItemButtonEdit.Click, AddressOf buttonColumnColumnProperties_Click
            MyBase.OnDeactivated()
        End Sub
    End Class
End Namespace
