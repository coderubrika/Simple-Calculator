using Assets.Scripts.Utility;
using Assets.Scripts.ViewModel;
using Assets.Scripts.ViewModel.Scriptable;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Model
{
    public sealed class Calculator : MonoBehaviour
    {
        private enum InputMode { LeftInput, OperatorInput, OnlyOperatorInput, RightInput, None }

        private InputMode _mode = InputMode.None;
        [SerializeField] private BinaryFloatOperator _defaultOperator;
        private BinaryFloatOperator _currentOperator;

        private List<char> _rightInputNumbers;
        private List<char> _leftInputNumbers;

        float? _leftNumber, _rightNumber;

        [SerializeField] private UnityEvent<string> _onRenderPreviewOutput;
        [SerializeField] private UnityEvent<string> _onRenderMainOutput;


        private void Awake()
        {
            _leftInputNumbers = new List<char>();
            _rightInputNumbers = new List<char>();
            _currentOperator = _defaultOperator;
        }

        private void RenderPreview()
        {
            string left = _leftNumber == null ? "" : ((float)_leftNumber).ToString();
            string right = _rightNumber == null ? "" : ((float)_rightNumber).ToString();

            if (_rightNumber == null)
            {
                _onRenderPreviewOutput.Invoke(left);
            }
            else
            {
                _onRenderPreviewOutput.Invoke($"{left}{_currentOperator.Char}{right}");
            }
            
        }

        private void RenderMainOutput()
        {
            _onRenderMainOutput.Invoke(CalcResult(_currentOperator.Operation.Operator).ToString());
        }

        private float CalcResult(Func<float, float, float> operation)
        {
            if (_leftNumber == null)
            {
                if (_leftInputNumbers.Count == 0) _leftNumber = 0f;
                else _leftNumber = float.Parse(ListCharToStr(_leftInputNumbers));
            }

            if (_rightNumber == null)
            {
                if (_rightInputNumbers.Count == 0) _rightNumber = 0f;
                else _rightNumber = float.Parse(ListCharToStr(_rightInputNumbers));
            }

            return operation((float)_leftNumber, (float)_rightNumber);
        }

        public void EnterNumber(NumberChar number)
        {
            if (_mode == InputMode.None)
            {
                _mode = InputMode.LeftInput;
            }

            if (_mode == InputMode.OperatorInput)
            {
                _mode = InputMode.RightInput;
            }

            if (_mode == InputMode.LeftInput)
            {
                PrepareNumber(_leftInputNumbers, number, ref _leftNumber);
            }

            if (_mode == InputMode.RightInput)
            {
                PrepareNumber(_rightInputNumbers, number, ref _rightNumber);
            }
        }

        private void PrepareNumber(List<char> inputNumbers, NumberChar number, ref float? fNumber)
        {
            List<char> testNumbers = new List<char>(inputNumbers);

            testNumbers.Add(number.Char);

            string numStr = ListCharToStr(testNumbers);

            try
            {
                int.Parse(numStr);

                inputNumbers.Add(number.Char);


                fNumber = float.Parse(numStr);


                RenderPreview();
                RenderMainOutput();
            }
            catch (Exception) { }
        }

        public void EnterBinaryOperator(BinaryFloatOperator floatOperator)
        {
            if (_mode == InputMode.LeftInput || _mode == InputMode.OperatorInput || _mode == InputMode.OnlyOperatorInput)
            {
                _mode = InputMode.OperatorInput;

                _currentOperator = floatOperator;

                RenderPreview();
            }

            
        }

        public void EnterActionOperator(ActionOperator actionOperator)
        {
            if (_mode == InputMode.RightInput && actionOperator.OperatorEnum == OperatorEnum.Equal)
            {
                _leftNumber = CalcResult(_currentOperator.Operation.Operator);

                _rightNumber = null;
                _currentOperator = _defaultOperator;
                _mode = InputMode.OnlyOperatorInput;

                _leftInputNumbers.Clear();
                _rightInputNumbers.Clear();

                RenderPreview();
                RenderMainOutput();
            }
        }

        private string ListCharToStr(List<char> list)
        {
            return new string(list.ToArray());
        }
    }
}