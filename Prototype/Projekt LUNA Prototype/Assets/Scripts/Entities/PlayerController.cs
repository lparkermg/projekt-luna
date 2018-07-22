using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using TMPro;

public class PlayerController : ManagedObjectBehaviour
{
    [SerializeField] private Characters _character;

    //Input
    private Player _currentPlayer;
    private bool _isControllable = true;

        //Human Form
    private float _humanMovement = 0.0f;
    private bool _jumpPressed = false;

    [SerializeField] private float _jumpForce = 1.0f;

        //Fairy Form
    private Vector2 _fairyMovement = new Vector2(0.0f,0.0f);

    //Rendering
    private SpriteRenderer _graphicsRenderer;

    [SerializeField] private Sprite _humanForm;
    [SerializeField] private Sprite _fairyForm;

    //Form
    [SerializeField] private bool _inFairyForm = false;

    //Physics
    private Rigidbody2D _rb;

    //External Forces
    private LevelManager _levelManager;

    #region Start and Update replacements
    public override void StartMe(GameObject managers)
    {
        _graphicsRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _levelManager = managers.GetComponent<LevelManager>();
        _graphicsRenderer.sprite = _inFairyForm ? _fairyForm : _humanForm;
        _rb.gravityScale = _inFairyForm ? 0.0f : 1.0f;
        _currentPlayer = ReInput.players.GetPlayer(0);
    }

    public override void UpdateMe()
    {
        if (_isControllable)
        {
            ProcessInput();
        }
        else
        {
            //TODO: Potentially put follow code here.
        }
    }
    #endregion

    #region Public Logic
    public void SwitchForm()
    {
        TransitionForm();
    }

    public void SetControlability(bool isControllable)
    {
        _isControllable = isControllable;
    }

    public bool IsSameCharacter(Characters character)
    {
        return _character == character;
    }
    #endregion

    #region Private Logic
    private void ProcessInput()
    {
        if (_inFairyForm)
        {
            _fairyMovement = _currentPlayer.GetAxis2D("MoveLeftRightFairy","MoveUpDownFairy");
            _rb.AddForce(_fairyMovement,ForceMode2D.Force);
        }
        else
        {
            _humanMovement = _currentPlayer.GetAxis("MoveLeftRightHuman");
            _jumpPressed = _currentPlayer.GetButtonDown("Jump");
            if (_jumpPressed)
            {
                _rb.AddForce(new Vector2(_humanMovement,_jumpForce),ForceMode2D.Impulse);
            }
            else
            {
                _rb.AddForce(new Vector2(_humanMovement, 0.0f),ForceMode2D.Force);
            }
        }

        if (_currentPlayer.GetButtonDown("SwapForm"))
        {
            if(!_inFairyForm)
                _levelManager.SwapLevels();
            SwitchForm();
        }
    }

    private void TransitionForm()
    {
        _inFairyForm = !_inFairyForm;

        if (_inFairyForm)
        {
            _graphicsRenderer.sprite = _fairyForm;
            _rb.gravityScale = 0.0f;
        }
        else
        {
            _graphicsRenderer.sprite = _humanForm;
            _rb.gravityScale = 1.0f;
        }
    }

    #endregion
}
