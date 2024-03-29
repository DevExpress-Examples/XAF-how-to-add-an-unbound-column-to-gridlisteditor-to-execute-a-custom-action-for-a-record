using System;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.ExpressApp;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.ExpressApp.Win.Editors;

namespace WinSolution.Module.Win {
    public class SimpleBusinessActionGridListViewController : ViewController<ListView> {
        private IModelColumn unboundModelColumn;
        private const string ButtonColumnCaption = "Action";
        private const string ButtonColumnName = "UnboundButtonColumn";
        private RepositoryItemButtonEdit activeRepositoryItemButtonEdit, inactiveRepositoryItemButtonEdit;
        private EditorButton activebutton = new EditorButton(ButtonPredefines.OK);
        private EditorButton inactivebutton = new EditorButton(ButtonPredefines.Close);
        private GridListEditor gridListEditor;
        public SimpleBusinessActionGridListViewController() {
            TargetObjectType = typeof(Order);
        }
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            gridListEditor = View.Editor as GridListEditor;
            if(gridListEditor != null) {
                InitGridView();
                InitButtonColumn();
            }
        }
        private void InitGridView() {
            gridListEditor.GridView.CustomRowCellEdit += gridView_CustomRowCellEdit;
            gridListEditor.GridView.CustomRowCellEditForEditing += gridView_CustomRowCellEdit;
            gridListEditor.GridView.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDown;
        }
        private void InitButtonColumn() {
            unboundModelColumn = (((IModelColumns)gridListEditor.Model.Columns).GetNode(ButtonColumnName) as IModelColumn);
            if(unboundModelColumn == null) {
                unboundModelColumn = gridListEditor.Model.Columns.AddNode<IModelColumn>(ButtonColumnName);
                unboundModelColumn.PropertyName = ButtonColumnName;
                unboundModelColumn.Width = 50;
                unboundModelColumn.PropertyEditorType = typeof(DefaultPropertyEditor);
                for(int i = gridListEditor.Columns.Count - 1; i >= 0; i--) {
                    ColumnWrapper cw = gridListEditor.Columns[i];
                    if(cw.PropertyName == unboundModelColumn.PropertyName) {
                        gridListEditor.RemoveColumn(cw);
                        break;
                    }
                }
                gridListEditor.AddColumn(unboundModelColumn);
            }
            GridColumn buttonColumn = gridListEditor.GridView.Columns[unboundModelColumn.PropertyName];
            if(buttonColumn != null) {
                buttonColumn.UnboundType = UnboundColumnType.Boolean;
                buttonColumn.Caption = ButtonColumnCaption;
                buttonColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                buttonColumn.VisibleIndex = 0;
                buttonColumn.OptionsColumn.AllowEdit = true;
                buttonColumn.OptionsColumn.AllowGroup = DefaultBoolean.False;
                buttonColumn.OptionsColumn.AllowMove = false;
                buttonColumn.OptionsColumn.AllowShowHide = false;
                buttonColumn.OptionsColumn.AllowSize = false;
                buttonColumn.OptionsColumn.AllowSort = DefaultBoolean.False;
                buttonColumn.OptionsColumn.FixedWidth = true;
                buttonColumn.OptionsColumn.ShowInCustomizationForm = false;
                buttonColumn.OptionsFilter.AllowFilter = false;
                InitButtonEditor(ref activeRepositoryItemButtonEdit, true);
                InitButtonEditor(ref inactiveRepositoryItemButtonEdit, false);
            }
        }
        private void InitButtonEditor(ref RepositoryItemButtonEdit properties, bool active) {
            properties = new RepositoryItemButtonEdit();
            properties.TextEditStyle = TextEditStyles.HideTextEditor;
            properties.Click += buttonColumnColumnProperties_Click;
            UpdateButtons(properties, active);
            gridListEditor.Grid.RepositoryItems.Add(properties);
        }
        private void UpdateButtons(RepositoryItemButtonEdit properties, bool active) {
            EditorButton button = active ? inactivebutton : activebutton;
            if(properties.Buttons[0].Kind != button.Kind) {
                properties.BeginInit();
                properties.Buttons.Clear();
                properties.Buttons.Add(button);
                properties.EndInit();
            }
        }
        private void gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
            if(e.Column.FieldName == ButtonColumnName) {
                ISimpleBusinessAction order = gridListEditor.GridView.GetRow(e.RowHandle) as ISimpleBusinessAction;
                if(order != null) {
                    e.RepositoryItem = order.Active ? activeRepositoryItemButtonEdit : inactiveRepositoryItemButtonEdit;
                }
            }
        }
        private void buttonColumnColumnProperties_Click(object sender, EventArgs e) {
            ButtonEdit editor = (ButtonEdit)sender;
            ISimpleBusinessAction order = gridListEditor.GridView.GetFocusedRow() as ISimpleBusinessAction;
            if(order != null) {
                order.SimpleBusinessAction();
                UpdateButtons(editor.Properties, order.Active);
            }
        }
        protected override void OnDeactivated() {
            if(gridListEditor != null && gridListEditor.GridView != null) {
                gridListEditor.GridView.CustomRowCellEdit -= gridView_CustomRowCellEdit;
                gridListEditor.GridView.CustomRowCellEditForEditing -= gridView_CustomRowCellEdit;
                if(unboundModelColumn != null)
                    unboundModelColumn.Remove();
            }
            if(activeRepositoryItemButtonEdit != null)
                activeRepositoryItemButtonEdit.Click -= buttonColumnColumnProperties_Click;
            if(inactiveRepositoryItemButtonEdit != null)
                inactiveRepositoryItemButtonEdit.Click -= buttonColumnColumnProperties_Click;
            base.OnDeactivated();
        }
    }
}