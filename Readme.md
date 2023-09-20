<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1748)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# XAF - Add an Unbound Column to GridListEditor to Execute a Custom Action for a Record

This example demonstrates how to add a custom unbound column with an Action to [GridControl](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.GridControl) in a List View. When a user clicks the Action button, XAF reverses the boolean value of the `Active` property of the selected `Order` object.

The following image demonstrates the result:

![ButtonInListEF Win_P73DZ29Ilj](https://github.com/DevExpress-Examples/XAF_how-to-add-an-unbound-column-to-gridlisteditor-to-execute-a-custom-action-for-a-record-e1748/assets/14300209/945f86b8-534f-4d02-aefa-56ad531f3249)

## Implementation Details

1. In the `Order` class, declare a public `SimpleBusinessAction` method to reverse the `Active` property.
2. Create a new column and configure its editor to add a custom unbound column to [GridControl](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.GridControl). For more information about [GridControl](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.GridControl) customization, refer to the following documentation topic: [Data Grid](https://docs.devexpress.com/WindowsForms/3455/controls-and-libraries/data-grid).

> [!TIP]
> For more information on how to implement an inline Action in an ASP.NET Core Blazor or ASP.NET Web Forms application, refer to the following documentation topic: [How to: Add a Grid Column with an Action (ASP.NET Core Blazor and ASP.NET Web Forms)](https://docs.devexpress.com/eXpressAppFramework/404559/ui-construction/controllers-and-actions/actions/how-to-add-a-grid-column-with-an-action).

## Files to Review

* [SimpleBusinessActionGridListViewController.cs](CS/EFCore/ButtonInListEF/ButtonInListEF.Win/Controllers/SimpleBusinessActionGridListViewController.cs) 
* [Order.cs](CS/EFCore/ButtonInListEF/ButtonInListEF.Module/BusinessObjects/Order.cs) 

## Documentation

* [How to: Add a Grid Column with an Action (ASP.NET Core Blazor and ASP.NET Web Forms)](https://docs.devexpress.com/eXpressAppFramework/404559/ui-construction/controllers-and-actions/actions/how-to-add-a-grid-column-with-an-action)
* [How to: Access the Grid Component in a List View](https://docs.devexpress.com/eXpressAppFramework/402154/ui-construction/list-editors/how-to-access-list-editor-control)
* [Assign Editors to Individual Cells](https://docs.devexpress.com/WindowsForms/5633/controls-and-libraries/tree-list/feature-center/data-editing/assigning-editors-to-individual-cells)
* [ActionAttribute Class](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ActionAttribute)
