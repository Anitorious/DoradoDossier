# Dorado Dossier
**Dossier**, A collection of papers giving detailed information about a particular person or subject.

Dorado Dossier is a 'Work in Progress' project that aspires to be a documentation & reporting library, leveraging the power
and familiarity of the .NET Razor Engine that allows developers to create dynamically generated documents with minimal effort.

**N.B**: This project is in the very early stages of research & development and is not ready for use in production environments.
Feedback at this point in time is valuable and all suggestions will be considered for this modules project plan.

## Installation
via Package Manager Console
```
Install-Package DoradoDossier
```

## Getting Started
### Dossier
Dorado works on the basis that users of the library follow a strict naming convention. To begin using Dorado, one must first
create a folder in the route of their project with the alias, 'Dossier'. 

Within this folder, we create a folder for each document we'd like the framework to resolve and render, with each folder containing
two files.

1.  The .cs file that inherits the IDossierQuery<T> interface named after the folder it is contained within with a post-fix of 'Dossier'.
2.  The razor partial template file named '_template'.

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

## License
The MIT License (MIT). Please see License File for more information.
