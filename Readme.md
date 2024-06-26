<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128587407/22.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1748)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [SimpleBusinessActionGridListViewController.cs](./CS/WinSolution.Module.Win/SimpleBusinessActionGridListViewController.cs) (VB: [SimpleBusinessActionGridListViewController.vb](./VB/WinSolution.Module.Win/SimpleBusinessActionGridListViewController.vb))
* [Order.cs](./CS/WinSolution.Module/Order.cs) (VB: [Order.vb](./VB/WinSolution.Module/Order.vb))
<!-- default file list end -->
# How to add an unbound column to GridListEditor to execute a custom action for a record


<p>This example shows how to add a custom unbound column to the GridControl in ListView. In the example, a button will be shown in this custom column. When a button is clicked, a custom business action will be executed on the selected record. To be more precise, the boolean Active property of the Order business class will be reversed.<br /> To accomplish this task, we will declare a public SimpleBusinessAction method within the Order class. This will allow to reverse the Active property because for demo purposes it won't have a public setter allowing to set this property directly.<br /> To add a custom unbound column to the GridControl, we will create a new column and configure its editor as needed. To learn more about the GridControl's customizations please refer to the XtraGrid's documentation.</p>
<p>Take special note that XAF Web applications support this scenario out-of-the-box. You can make a method within your business class and mark it with the <a href="https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ActionAttribute">ActionAttribute</a>. Then, XAF will produce an Action column in the List View for your business class. Refer to the documentation for more details.<br /><br /><strong>IMPORTANT NOTES</strong><br />One of the prerequisites for this particular solution and the DataAccessMode = Server mode is to have a valid IModelMember defined in the Application Model. You can do this via the Model Editor as described in the <a href="https://documentation.devexpress.com/#Xaf/CustomDocument3583">eXpressApp Framework > Concepts > Business Model Design > Types Info Subsystem > Customize Business Object's Metadata</a> article.<br /><br /></p>
<p><strong>See Also:</strong><br /> <a href="https://www.devexpress.com/Support/Center/p/K18108">How to provide an inline Action shown right within the ListView control row on the Web</a><br /> <a href="https://docs.devexpress.com/eXpressAppFramework/113165/getting-started/in-depth-tutorial-winforms-aspnet/extend-functionality/access-grid-control-properties">Access Grid Control Properties</a><br /> <a href="https://docs.devexpress.com/WindowsForms/5633/controls-and-libraries/tree-list/feature-center/data-editing/assigning-editors-to-individual-cells">Assigning Editors to Individual Cells</a><br /> <br /> <a href="https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ActionAttribute">ActionAttribute Class</a></p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF-how-to-add-an-unbound-column-to-gridlisteditor-to-execute-a-custom-action-for-a-record&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF-how-to-add-an-unbound-column-to-gridlisteditor-to-execute-a-custom-action-for-a-record&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
