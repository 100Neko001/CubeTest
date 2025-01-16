using UnityEngine;
using UnityEngine.VFX;
using System.Linq;

[RequireComponent(typeof(VisualEffect))]
public class VFXPositionController : MonoBehaviour
{
    enum SpaceType
    {
        World,
        Local
    }

    VisualEffect vfx;
    [SerializeField] private string propertyId = "position";
    [SerializeField] ColliderTriggetEvent[] positionReferences = new ColliderTriggetEvent[5];
    [SerializeField] SpaceType positionMode = SpaceType.World;
    [SerializeField] int currentIndex = 0;

    private void Start()
    {
        vfx = GetComponent<VisualEffect>();

        // positionReferencesからnullの要素を除く
        positionReferences = RemoveNullReferences(positionReferences);

        System.Array.ForEach(positionReferences, pr =>
        {
            pr.onTriggerEnter.AddListener(() => OnTriggerEnter(pr.transform));
        });
    }

    Vector3 GetOutputPosition(Transform collider, SpaceType spaceType)
    {
        if (collider == null)
        {
            Debug.LogWarning("無効なColliderが渡されました。");
            return Vector3.zero;
        }

        return spaceType == SpaceType.World ? collider.position : collider.localPosition;
    }

    private void OnTriggerEnter(Transform collider)
    {
        if (positionReferences.Length == 0)
        {
            Debug.LogWarning("位置参照が設定されていません。");
            return;
        }

        // 接触したColliderの座標を取得
        Vector3 position = GetOutputPosition(collider, positionMode);

        // VFXに座標を設定
        vfx.SetVector3(propertyId, position);

        Debug.Log($"VFXに位置を設定しました: {position}");
    }

    private ColliderTriggetEvent[] RemoveNullReferences(ColliderTriggetEvent[] references)
    {
        // nullでない要素のみを抽出して新しい配列を作成
        return System.Array.FindAll(references, reference => reference != null);
    }
}