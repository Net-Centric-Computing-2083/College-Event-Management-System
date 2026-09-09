Put the college logo image in this folder with the file name:

    logo.png

Steps in Visual Studio:
1. Right click on the Assets folder -> Add -> Existing Item -> select logo.png
2. Select logo.png in Solution Explorer.
3. In the Properties window set "Copy to Output Directory" = "Copy if newer".
4. Run the application. The header will show the image instead of the text placeholder.

If no logo file is supplied, the application shows a clean
"ORCHID COLLEGE" text placeholder in the header. No fake logo is used.
