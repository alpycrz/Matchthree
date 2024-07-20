using Components;
using Events;
using UI.Utils;
using UnityEngine;
using Zenject;

public class ResumeGameBTN : UIBTN
{
    [Inject] private MainUIEvents MainUIEvents { get; set; }

    protected override void OnClick() => MainUIEvents.ResumeBTN?.Invoke();
}
