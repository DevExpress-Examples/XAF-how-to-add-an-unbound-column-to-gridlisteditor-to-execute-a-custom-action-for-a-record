<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128587407/22.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1748)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# XAF - Add a Command  Column to a GridListEditor (an Unbound Column with a Custom Action)

This example adds an unbound column to the [GridControl](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.GridControl) in a List View. Column cells contain buttons that invoke custom actions. When a user clicks a button, the Action obtains the selected `Order` object and toggles the value of the `Active` property.

The following image demonstrates the result:

![ButtonInListEF Win_P73DZ29Ilj](https://github.com/DevExpress-Examples/XAF_how-to-add-an-unbound-column-to-gridlisteditor-to-execute-a-custom-action-for-a-record-e1748/assets/14300209/945f86b8-534f-4d02-aefa-56ad531f3249)

## Implementation Details

1. In the `Order` class, declare a public `SimpleBusinessAction` method that toggles the `Active` property.
2. Create a new unbound column and configure its editor. Add the column to the [GridControl](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.GridControl). For more information about [GridControl](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.GridControl) customization, refer to the following documentation topic: [Data Grid](https://docs.devexpress.com/WindowsForms/3455/controls-and-libraries/data-grid).

> **Note**  
> For more information on how to implement an inline Action in an ASP.NET Core Blazor or ASP.NET Web Forms application, refer to the following documentation topic: [How to: Add a Grid Column with an Action (ASP.NET Core Blazor and ASP.NET Web Forms)](https://docs.devexpress.com/eXpressAppFramework/404559/ui-construction/controllers-and-actions/actions/how-to-add-a-grid-column-with-an-action?v=23.2).

## Files to Review

* [SimpleBusinessActionGridListViewController.cs](CS/EFCore/ButtonInListEF/ButtonInListEF.Win/Controllers/SimpleBusinessActionGridListViewController.cs) 
* [Order.cs](CS/EFCore/ButtonInListEF/ButtonInListEF.Module/BusinessObjects/Order.cs) 

## Documentation

* [How to: Add a Grid Column with an Action (ASP.NET Core Blazor and ASP.NET Web Forms)](https://docs.devexpress.com/eXpressAppFramework/404559/ui-construction/controllers-and-actions/actions/how-to-add-a-grid-column-with-an-action?v=23.2)
* [How to: Access the Grid Component in a List View](https://docs.devexpress.com/eXpressAppFramework/402154/ui-construction/list-editors/how-to-access-list-editor-control)
* [Assign Editors to Individual Cells](https://docs.devexpress.com/WindowsForms/5633/controls-and-libraries/tree-list/feature-center/data-editing/assigning-editors-to-individual-cells)
* [ActionAttribute Class](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ActionAttribute)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF-how-to-add-an-unbound-column-to-gridlisteditor-to-execute-a-custom-action-for-a-record&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF-how-to-add-an-unbound-column-to-gridlisteditor-to-execute-a-custom-action-for-a-record&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
