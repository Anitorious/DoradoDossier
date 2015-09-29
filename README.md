# Dorado Dossier
**Dossier**, A collection of papers giving detailed information about a particular person or subject.

Dorado Dossier is a '*work in progress*' project that aspires to be a documentation & reporting library, leveraging the power of the .NET Razor Engine, to allow developers to create dynamic documents with minimal effort.

**N.B**: This project is currently in early stages of development and is not ready for use in production environments. Feedback is valuable to the improvement and growth of the project and every suggestion will be incorperated where appropriate.

## Installation
via Package Manager Console
```
Install-Package DoradoDossier
```

## Getting Started
### Dossier
Dorado works on the basis that users of the library follow a strict naming convention. To begin using Dorado, one must first create a folder in the route of their project with the alias, 'Dossier'. 

Within this folder, we must create a folder for each document we'd like the library to resolve and render, with each folder containing:

1. .cs file that inherits the IDossierQuery&lt;T&gt; interface with an alias of *"Parent Folder" + "Dossier"*, for example; "MyDocumentDossier".
2.  Template file named '_template'.

####Example
##### Directory Structure
```
|- Dossier
  |- MyDocument
    |- MyDocumentDossier.cs
    |- _template.cshtml
```
##### MyDocumentDossier.cs
```
public class MyDocumentDossier : IDossierQuery<IQueryable<string>>
{
    public IQueryable<string> ResolveTemplateQuery()
    {
        var l = new List<string>() { "Foo", "Bar" };
         return l.AsQueryable();
    }
}
```

##### _template.cshtml
```
@model IEnumerable<string>

<ul>
    @foreach (var item in Model)
    {
        <li>@item</li>
    }
</ul>
```
For more information on the limits of the Razor Engine, look to the latest documentation for the latest stable release
at https://antaris.github.io/RazorEngine/

**N.B**: ViewBag data is currently not supported by Dorado Dossier.

##### Usage
```
Dossier<IQueryable<string>> dossier = new Dossier<IQueryable<string>>();

// Binding a Dossier returns the rendered template as a string representation of the HTML output.
string html = dossier.BindDossier("MyDocument");
```

##### Result
```
<ul>
  <li>Foo</li>
  <li>Bar</li>
</ul>
```

## License
The MIT License (MIT). Please see License File for more information.
