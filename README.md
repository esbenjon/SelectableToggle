# SelectableToggle
**A simple toggle UI control for Unity3D, based on the Selectable component**

This is a simple UI control used for selecting a single element among a group of similar elements. This is mostly used as elements in lists.
Unity does not seem to have a similar component, the exisiting Selectable component is mostly used to press things, while the Toggle is a checkmark widget.

**Usage:**

Add SelectableToggle to each element, they all need to be siblings, ie they must all have the same parent object. This can be done either in the inspector or programatically.
Settings in the inspector will be similar to the existing Selectable component.
To determine if an element has been selected by the user, use the **selected** or **selectedItem** properties. The first will return the index of the selected item, -1 if no item was selected. The latter will return the Transform of the selected item or null if nothing is selected.

Currently the component does not support multi-selection.
