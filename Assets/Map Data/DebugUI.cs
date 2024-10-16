using UniRx;    // Added
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// For the sake of XML documentation, you need three forward slashes.
/// <summary>
/// UI for Debug
/// </summary>
public class DebugUI : MonoBehaviour
{
    [SerializeField] private Slider _sliderPosX, _sliderPosY, _sliderPosZ, _sliderRotY;
    [SerializeField] private Text _textPosX, _textPosY, _textPosZ, _textRotY;
    [SerializeField] private Button _hideButton, _showButton;
    [SerializeField] private Toggle  _materialToggle;
    [SerializeField] private GameObject _debugUiParent;
    [SerializeField] private GameObject _immersalMesh;
    [SerializeField] private Transform _plateauParentTransform;
    [SerializeField] private Material _occlusionMaterial, _defaultMaterial;

    private Vector3 _starLocalPos;
    private Vector3 _starLocalEuler;

    private const float POS_VALUE_RANGE_ABS = 50;
    private const float ROT_VALUE_RANGE_ABS = 360;

    // Start is called before the first frame update
    void Start()
    {
       // Click Hide Button
       // OncClickAsObservable() is used for a button
       _hideButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                _debugUiParent.SetActive(false);
                _showButton.gameObject.SetActive(true); // What's the relationship between showButton and gameObject?
                                                        // Do I have to set a gameObject to _showButton?
                                                        // Maybe _showButton is a little button to swith show/hide a big show/hide button
                _immersalMesh.SetActive(false);
            }) 
            .AddTo(this);   // "this" represent the instance of this object.

        //Click Show Button
        _showButton.OnClickAsObservable()
            .Subscribe(_ => 
            {
                _debugUiParent.SetActive(true);
                _showButton.gameObject.SetActive(false); // What's the relationship between showButton and gameObject?
                _immersalMesh.SetActive(true);
            })
            .AddTo(this);

//        // Toggle to switch Material
//        // OnValueChangedAsObservale() is used for toggle, slider, input field.
//        _materialToggle.OnValueChangedAsObservable()
//            .Subscribe(toggleValue => 
//            {
//                foreach (Transform child in _plateauParentTransform)
//                {
//
//                }      
//            })

          // Initialization
         _starLocalPos = _plateauParentTransform.localPosition;
         _starLocalEuler = _plateauParentTransform.localEulerAngles;
         _sliderPosX.value = 0.5f;
         _sliderPosY.value = 0.5f;
         _sliderPosZ.value = 0.5f;
         _sliderRotY.value = 0.5f;
         _textPosX.text = _starLocalPos.x.ToString();
         _textPosY.text = _starLocalPos.y.ToString();
         _textPosZ.text = _starLocalPos.z.ToString();
         _textRotY.text = _starLocalEuler.y.ToString();

         // Slider to control X direction
         // What number is "value" likely to take? 0 to 1?
         _sliderPosX.OnValueChangedAsObservable()
             .Subscribe(value =>
             {
                 // Format the value
                 // Mathf.Floor rounds down the value.
                 // Matchf stands for Math Float, collection optimized for working with floating-point numbers.
                 // When value is 0, it'll be -0.5 and when the value is 1, it'll be 0.5
                 // 1. Center the value between -0.5 to 0.5
                 // 2. Multiply by 100
                 // 3. Rounds down
                 // 4. Divide by 100
                 // 5. Fit the value between -50 to 50
                 var arrangeValue = Mathf.Floor((value - 0.5f) * 100) / 100 * POS_VALUE_RANGE_ABS;   // "float" is preferred than "var"?
                 _textPosX.text = SetPositionX(arrangeValue).ToString();
             })
             .AddTo(this);

         // Slider to control Y direction
         _sliderPosY.OnValueChangedAsObservable().
             Subscribe(value => 
             {
                 var arrangeValue = Mathf.Floor((value - 0.5f) * 100) / 100 * POS_VALUE_RANGE_ABS;   // "float" is preferred than "var"?
                 _textPosY.text = SetPositionY(arrangeValue).ToString();
             })
             .AddTo(this);

         // Slider to control Z direction
         _sliderPosZ.OnValueChangedAsObservable().
             Subscribe(value => 
             {
                 var arrangeValue = Mathf.Floor((value - 0.5f) * 100) / 100 * POS_VALUE_RANGE_ABS;   // "float" is preferred than "var"?
                 _textPosZ.text = SetPositionZ(arrangeValue).ToString();
             })
             .AddTo(this);

         // Slider to control the rotation around Y axis
         _sliderRotY.OnValueChangedAsObservable().
             Subscribe(value => 
             {
                 var arrangeValue = Mathf.Floor((value - 0.5f) * 100) / 100 * ROT_VALUE_RANGE_ABS;   // "float" is preferred than "var"?
                 _textRotY.text = SetRotationY(arrangeValue).ToString();
             })
             .AddTo(this);   }



    /// <summary>
    /// Move the object in X direction by the given value
    /// </summary>
    /// <param name="x"> Coordinate </param>
    private float SetPositionX(float x)
    {
        var currentPos = _plateauParentTransform.localPosition;
        var pos = new Vector3(_starLocalPos.x, currentPos.y, currentPos.z);
        pos.x += x;
        _plateauParentTransform.localPosition = pos;
        return pos.x;
    }

    /// <summary>
    /// Move the object in Y direction by the given value
    /// </summary>
    /// <param name="y"> Coordinate </param>
    private float SetPositionY(float y)
    {
        var currentPos = _plateauParentTransform.localPosition;
        var pos = new Vector3(currentPos.x, _starLocalPos.y, currentPos.z);
        pos.y += y;
        _plateauParentTransform.localPosition = pos;
        return pos.y;
    }

    /// <summary>
    /// Move the object in Z direction by the given value
    /// </summary>
    /// <param name="z"> Coordinate </param>
    private float SetPositionZ(float z)
    {
        var currentPos = _plateauParentTransform.localPosition;
        var pos = new Vector3(currentPos.x, _starLocalPos.y, currentPos.z);
        pos.z += z;
        _plateauParentTransform.localPosition = pos;
        return pos.z;
    }

    /// <summary>
    /// Rotate the object around Y axis by the given value
    /// </summary>
    /// <param name="y"> Coordinate </param>
    private float SetRotationY(float y)
    {
        var eulerAngles = _starLocalEuler;
        eulerAngles.y += y;
        _plateauParentTransform.localEulerAngles = eulerAngles;
        return eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
