Notes on this Custom  Implementation of Nustache
------------------------------------------------------------------

This version has a number of key differences that allowed us to tailor the functionality we wanted out of Nustache

__Preserving Undefined Variables__

- The original implementation removes any undefined variables from the populated template

- This is great for a live environment; however we wanted to write integration tests that ensured all variables were catered for
    - We cannot do this if the variables are removed even if not catered for

- So the methods on this version now take in an optional "Options" object
    - This object has a "PreserveUndefinedVariables" property
    - If not provided; Nustache reverts to it's original implementation
    - Otherwise any parameters without a matching property / field in the given object will be left in the template

__Html Encoding of Triple Mustache Tags__

- The mustache specification indicates that:
    - {{value}} html encodes
    - {{{value}}} presents the raw text (allowing us to inject html into the templates)

- This is functionality we didn't need; however we did want the ability to preserve line breaks on body text

- Therefore in our implementation {{{value}}} 
    - Html encodes as {{value}} would
    - Convereted any "\n" characters into "&lt;br /&gt;" tags

Nustache - Logic-less templates for .NET
-----------------------------------------------------

For a list of implementations (other than .NET) and editor plugins, see
http://mustache.github.com/.

Installation:

- Pull from GitHub or download the repository and build it.
- Or, install via NuGet (search for Nustache).
- If you're using MVC, you'll want to build/install the Nustache.Mvc3 project,
  too.

Usage:

For non-MVC projects:

- Add a reference to Nustache.Core.dll (done for you if you used NuGet).
- Import the Nustache.Core namespace.
- Use one of the static, helper methods on the Render class.

    var html = Render.FileToString("foo.template", myData);

- Data can be object, IDictionary, or DataTable.
- If you need more control, use Render.Template.
- See the source and tests for more information.

For MVC projects:

- Add a reference to Nustache.Mvc3.dll (done for you if you used NuGet).
- Add NustacheViewEngine to the global list of view engines.
- See Global.asax.cs in the Nustache.Mvc3.Example project for an example.

nustache.exe:

- Command-line wrapper around Render.FileToFile.
- Parameters are templatePath, dataPath, and outputPath.
- Reads JSON or XML from dataPath for data.
  - If extension is .js or .json, assumes JSON. Must wrap with { }.
  - If extension is .xml, assumes XML. Initial context is the document element.

    nustache.exe foo.template myData.json foo.html

- External templates are assumed to be in the same folder as the template
  mentioned in templatePath.
- Extension is also assumed to be the same as the template in templatePath.

Syntax:

- The same as Mustache with some extensions.
- Support for defining internal templates:

    {{<foo}}This is the foo template.{{/foo}}
    The above doesn't get rendered until it's included
    like this:
    {{>foo}}
    You can define templates inside sections. They override
    templates defined in outer sections which override
    external templates.
