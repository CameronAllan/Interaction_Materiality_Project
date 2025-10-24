using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectTrackUI : MonoBehaviour
{
    [SerializeField] private EffectTimelineUI _parent;

    [SerializeField] private Image _trackImage;
    public InteractionManager.InteractionTypes TrackType { get; private set; }

    [SerializeField] private List<InteractionChain> _displayed;

    [SerializeField] private Transform _entryHolder;
    [SerializeField] private List<EffectEntryUI> _activeEntries;


    public void PopulateTrackUI(List<EffectSlot> track, EffectTimelineUI parentUI)
    {
        _parent = parentUI;

        foreach(EffectEntryUI entry in _activeEntries)
        {
            entry.DeselectEntry();
            entry.gameObject.SetActive(false);
        }

        for(int x = 0; x < track.Count; x++)
        {
            if(x < _activeEntries.Count)
            {
                _activeEntries[x].gameObject.SetActive(true);
                _activeEntries[x].SetEffectSlot(track[x], this);
            }
        }
    }

    public void EntrySelected(EffectEntryUI entry)
    {
        _parent.EntrySelected(entry);
    }

    public void ClearEntries(EffectEntryUI entry)
    {
        foreach(EffectEntryUI e in _activeEntries)
        {
            if(e != entry)
            {
                e.DeselectEntry();
            }
        }
    }
}
