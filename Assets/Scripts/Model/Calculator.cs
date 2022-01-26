using Assets.Scripts.Utility;
using Assets.Scripts.ViewModel;
using Assets.Scripts.ViewModel.Scriptable;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Model
{
    public class Calculator : MonoBehaviour
    {
        private enum InputMode { LeftInput, OperatorInput, OnlyOperatorInput, RightInput, None }

        private InputMode mode = InputMode.None;
        [SerializeField] private BinaryFloatOperator _defaultOperator;
        private BinaryFloatOperator _currentOperator;

        private List<char> rightInputNumbers;
        private List<char> leftInputNumbers;

        float? leftNumber, rightNumber;

        [SerializeField] private UnityEvent<string> _onRenderPreviewOutput;
        [SerializeField] private UnityEvent<string> _onRenderMainOutput;


        private void Awake()
        {
            leftInputNumbers = new List<char>();
            rightInputNumbers = new List<char>();
            _currentOperator = _defaultOperator;
        }

        private void RenderPreview()
        {
            string left = leftNumber == null ? "" : ((float)leftNumber).ToString();
            string right = rightNumber == null ? "" : ((float)rightNumber).ToString();

            if (rightNumber == null)
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
            if (leftNumber == null)
            {
                if (leftInputNumbers.Count == 0) leftNumber = 0f;
                else leftNumber = float.Parse(ListCharToStr(leftInputNumbers));
            }

            if (rightNumber == null)
            {
                if (rightInputNumbers.Count == 0) rightNumber = 0f;
                else rightNumber = float.Parse(ListCharToStr(rightInputNumbers));
            }

            return operation((float)leftNumber, (float)rightNumber);
        }

        public void EnterNumber(NumberChar number)
        {
            if (mode == InputMode.None)
            {
                mode = InputMode.LeftInput;
            }

            if (mode == InputMode.OperatorInput)
            {
                mode = InputMode.RightInput;
            }

            if (mode == InputMode.LeftInput)
            {
                List<char> testNumbers = new List<char>(leftInputNumbers);

                testNumbers.Add(number.Char);

                string numStr = ListCharToStr(testNumbers);

                try
                {
                    int.Parse(numStr);

                    leftInputNumbers.Add(number.Char);


                    leftNumber = float.Parse(numStr);

                    
                    RenderPreview();
                    RenderMainOutput();
                }
                catch (Exception) { }
            }

            if (mode == InputMode.RightInput)
            {
                List<char> testNumbers = new List<char>(rightInputNumbers);

                testNumbers.Add(number.Char);

                string numStr = ListCharToStr(testNumbers);

                try
                {
                    int.Parse(numStr);

                    rightInputNumbers.Add(number.Char);

                    rightNumber = float.Parse(numStr);
                  
                    RenderPreview();
                    RenderMainOutput();

                }
                catch (Exception) { }
            }
        }

        public void EnterBinaryOperator(BinaryFloatOperator floatOperator)
        {
            if (mode == InputMode.LeftInput || mode == InputMode.OperatorInput || mode == InputMode.OnlyOperatorInput)
            {
                mode = InputMode.OperatorInput;

                _currentOperator = floatOperator;

                RenderPreview();
            }

            
        }

        public void EnterActionOperator(ActionOperator actionOperator)
        {
            if (mode == InputMode.RightInput && actionOperator.operatorEnum == OperatorEnum.Equal)
            {
                leftNumber = CalcResult(_currentOperator.Operation.Operator);

                rightNumber = null;
                _currentOperator = _defaultOperator;
                mode = InputMode.OnlyOperatorInput;

                leftInputNumbers.Clear();
                rightInputNumbers.Clear();

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