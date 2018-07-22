using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class UiManager : ManagedObjectBehaviour
{
    [SerializeField] private CanvasGroup _storyUi;
    [SerializeField] private Text _characterName;
    [SerializeField] private Text _storyContent;

    private bool _tellingTale = false;

    private Player _player;
    private PlayerController _storyInitiator;

    private StoryItem[] _currentStory;
    private int _currentStoryItem = 0;
    
    public override void StartMe(GameObject managers)
    {
        _player = ReInput.players.GetPlayer(0);
    }

    public override void UpdateMe()
    {
        if (_tellingTale)
        {
            ProcessInput();
        }
    }

    public void StartStory(StoryItem[] storyItems, PlayerController storyInitiator)
    {
        _storyInitiator = storyInitiator;
        _currentStory = storyItems;
        _currentStoryItem = 0;
        UpdateStory();
        _tellingTale = true;
        _storyUi.Show();
    }

    private void ProcessInput()
    {
        if (_player.GetButtonDown("Jump"))
        {
            if (_currentStoryItem >= _currentStory.Length - 1)
            {
                ExitStory();
            }
            else
            {
                _currentStoryItem++;
                UpdateStory();
            }
        }
        else if (_player.GetButtonDown("Skip"))
        {
            ExitStory();
        }
    }

    private void UpdateStory()
    {
        _characterName.text = _currentStory[_currentStoryItem].CharacterName;
        _storyContent.text = _currentStory[_currentStoryItem].StoryContent;

    }

    private void ExitStory()
    {
        _storyUi.Hide();
        _tellingTale = false;
        _storyInitiator.SetControlability(true);
        _storyInitiator = null;
    }
}
