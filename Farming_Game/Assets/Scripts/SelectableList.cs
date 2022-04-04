using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableList
{
    private List<ISelectable> selectableList;
    ISelectable selected;
    int idx;

    public SelectableList()
    {
        selectableList = new List<ISelectable>();
        selected = null;
        idx = 0;
    }

    public void SelectableInRange(ISelectable selectable)
    {
        selectableList.Add(selectable);
        selectable.GetInRange();

        if (selected == null)
        {
            selectable.Select();
            selected = selectable;
        }
        idx = 0;
    }

    public void SelectableOutOfRange(ISelectable selectable)
    {
        selectableList.Remove(selectable);
        selectable.GetOutOfRange();

        if (selectable == selected && selectableList.Count != 0)
        {
            selected = selectableList[0];
            selected.Select();
        }

        if (selectableList.Count == 0)
        {
            selected = null;
        }

        idx = 0;
    }

    public void Next()
    {
        idx = (idx + 1) % selectableList.Count;

        selected.Unselect();
        selected = selectableList[idx];
        selected.Select();

    }
    public void Previous()
    {
        idx--;
        if (idx < 0)
        {
            idx += selectableList.Count;
        }

        selected.Unselect();
        selected = selectableList[idx];
        selected.Select();
    }


    public ISelectable GetSelected()
    {
        selectableList.Remove(selected);
        selected.GetOutOfRange();
        return selected;
    }
    public int Count()
    {
        return selectableList.Count;
    }
    public void Clear()
    {
        foreach (ISelectable selectable in selectableList)
        {
            selectable.GetOutOfRange();
        }        
        //selected = null;
        selectableList.Clear();
    }
}
