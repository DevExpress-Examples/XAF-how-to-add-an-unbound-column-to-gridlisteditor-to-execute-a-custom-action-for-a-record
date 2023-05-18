<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128587407/22.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1748)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [SimpleBusinessActionGridListViewController.cs](CS/EFCore/ButtonInListEF/ButtonInListEF.Win/Controllers/SimpleBusinessActionGridListViewController.cs) 
* [Order.cs](CS/EFCore/ButtonInListEF/ButtonInListEF.Module/BusinessObjects/Order.cs) 
<!-- default file list end -->
# How to add an unbound column to GridListEditor to execute a custom action for a record


<p>This example shows how to add a custom unbound column to the GridControl in ListView. In the example, a button will be shown in this custom column. When a button is clicked, a custom business action will be executed on the selected record. To be more precise, the boolean Active property of the Order business class will be reversed.<br /> To accomplish this task, we will declare a public SimpleBusinessAction method within the Order class. This will allow to reverse the Active property.<br /> To add a custom unbound column to the GridControl, we will create a new column and configure its editor as needed. To learn more about the GridControl's customizations please refer to the XtraGrid's documentation.</p>
<p>Take special note that XAF Web applications support this scenario out-of-the-box. You can make a method within your business class and mark it with the <a href="https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ActionAttribute">ActionAttribute</a>. Then, XAF will produce an Action column in the List View for your business class. Refer to the documentation for more details.<br />
<p><strong>See Also:</strong><br /> <a href="https://www.devexpress.com/Support/Center/p/K18108">How to provide an inline Action shown right within the ListView control row on the Web</a><br /> <a href="https://docs.devexpress.com/eXpressAppFramework/113165/getting-started/in-depth-tutorial-winforms-aspnet/extend-functionality/access-grid-control-properties">Access Grid Control Properties</a><br /> <a href="https://docs.devexpress.com/WindowsForms/5633/controls-and-libraries/tree-list/feature-center/data-editing/assigning-editors-to-individual-cells">Assigning Editors to Individual Cells</a><br /> <br /> <a href="https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ActionAttribute">ActionAttribute Class</a></p>

<br/>


