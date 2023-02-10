// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Examples.Experimental.DialogTest
{

    public class DialogExampleController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Assign DialogLarge_192x192.prefab")]
        private GameObject dialogPrefabLarge;

        /// <summary>
        /// Large Dialog example prefab to display
        /// </summary>
        public GameObject DialogPrefabLarge
        {
            get => dialogPrefabLarge;
            set => dialogPrefabLarge = value;
        }

        void Start()
        {
            string dialogString = "Here we visualize a K-Nearest-Neighbor classifier, which is a very simple approach of Machine Learning. First, you can scan Tutorial Cards. The model will learn the gender, the weight, the height and the hairvolume from this training instances. After training, the model can be tested with Test Cards. There, only weight, height and hairvolume is given - the gender (the Target Attribute) is missing. The task of the model is now to classify the gender of the card, based on the given height, weight and hairvolume of the test card and the learned training examples.\n If you want to reset the cards you already scanned, just scan the Reset Card.\n Now just give it a try :)";
            Dialog.Open(DialogPrefabLarge, DialogButtonType.OK, "Welcome to this learning application!", dialogString, true);
        }

    }
}
