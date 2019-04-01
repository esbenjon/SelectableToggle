/*
Copyright 2019 Esben Jon Jensen

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// Extension of UnityEngine.UI.Selectable for toggle selection
/// All siblings of type SelectableToggle will be considered part of the selection group
/// </summary>
/// \todo Add support for multi selection
public class SelectableToggle : Selectable, ISelectHandler, IPointerClickHandler {
    private bool _selected = false;

    /// <summary>
    /// Whether the item is currently selected
    /// </summary>
    public bool selected {
        get { return _selected; }
    }

    /// <summary>
    /// Reference to the selected item
    /// </summary>
    public Transform selectedItem {
        get {
            Transform parent = transform.parent;

            SelectableToggle[] siblings = parent.GetComponentsInChildren<SelectableToggle>();

            foreach (SelectableToggle sibling in siblings) {
                if (sibling.selected) { return sibling.transform; }
            }

            return null;
        }
    }

    /// <summary>
    /// Zero based index of the selected item. The index will count all siblings, not just those of type SelectableToggle 
    /// </summary>
    public int selectedIndex {
        get {
            Transform parent = transform.parent;

            SelectableToggle[] siblings = parent.GetComponentsInChildren<SelectableToggle>();

            foreach (SelectableToggle sibling in siblings) {
                if (sibling.selected) { return sibling.transform.GetSiblingIndex(); }
            }
            return -1;
        }
    }

    private void Deselect(BaseEventData eventData) {
        _selected = false;
        base.OnDeselect(eventData);
    }

    public override void OnSelect(BaseEventData eventData) {
    }

    public override void OnDeselect(BaseEventData eventData) {
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (!selected) {
            base.OnSelect(eventData);
            _selected = true;

            Transform parent = transform.parent;

            SelectableToggle[] siblings = parent.GetComponentsInChildren<SelectableToggle>();

            foreach (SelectableToggle sibling in siblings) {
                if (sibling != this) {
                    sibling.Deselect(eventData);
                }
            }
        } else {
            Deselect(eventData);
        }


    }
}
