using System;
using UnityEngine;
using UnityEngine.Networking;

namespace BerserkPixel.Readme
{
    public static class NetworkManager
    {
        private static UnityWebRequest _request;

        public static void GetVersion(string assetName, string url, Action<string> callback)
        {
            GetRequest(url, request =>
            {
#if UNITY_2020_3_OR_NEWER
                if (request.result == UnityWebRequest.Result.Success)
                {
#else
            if (!request.isNetworkError && !request.isHttpError) {
#endif
                    var text = request.downloadHandler.text;
                    callback(text);
                }
                else
                {
                    Debug.LogError($"[{assetName}] {request.error}: {request.downloadHandler.text}.");
                }
            });
        }

        private static void GetRequest(string url, Action<UnityWebRequest> callback)
        {
            if (_request != null) return;

            _request = UnityWebRequest.Get(url);
            var op = _request.SendWebRequest();
            op.completed += operation =>
            {
                callback(_request);
                _request.Dispose();
                _request = null;
            };
        }
    }
}