#########
HELP - The information below can also be located on the main window and 
comes with pictures.
#########

-Template Manager-

Template Manager is a tool that can be used to view script templates you have 
installed as well as adding or deleting your own. This tool is designed to save 
you the effort of manually creating your own templates as well as a host of 
other useful functions.

-How to format your template script-

Make your template script like you would any other script.
Replace each instance where you would use the main method's name with
'#SCRIPTNAME#'.

-Fields-

Script
Place the script you want to be added as a new template in this field.

Menu Location
This field will determine where you can find your script. The format is 
'Folder__Name' or just 'Name'. You must have two underscores between your folder
and name.
Example: CustomFolder__EditorScript

Default Name
This is the default name that scripts following this template will take.
Example: NewEditorScript

Extension
The extension the file should have when it is created.
Example: cs

Menu Order
This integer will determine the order your template will appear in the create 
asset menu. Unity's own assets occupy spaces 1-1000 but duplicates are allowed.
Example: 200