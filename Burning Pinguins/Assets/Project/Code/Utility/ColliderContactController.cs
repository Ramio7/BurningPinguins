using UnityEngine;

public class ColliderContactController
{
    private float _contactThreshold = 0.5f;
    private ContactPoint[] _contactPoints;
    private int _contactsCount;
    private Collider _collider;

    public bool IsGrounded { get; private set; }
    public bool IsRightContact { get; private set; }
    public bool IsLeftContact { get; private set; }
    public bool IsForwardContact { get; private set; }
    public bool IsBackwardContact { get; private set; }
    public bool IsUpperContact { get; private set; }

    public ColliderContactController(Collider collider)
    {
        _contactPoints = new ContactPoint[10];
        _collider = collider;
        GameEntryPoint.Instance.OnUpdateEvent += OnUpdate;
    }

    private void OnUpdate()
    {
        IsGrounded = false;
        IsRightContact = false;
        IsLeftContact = false;
        IsForwardContact = false;
        IsBackwardContact = false;
        IsUpperContact = false;

        _contactsCount = (int)_collider.contactOffset;

        for (int i = 0; i < _contactsCount; i++)
        {
            var normal = _contactPoints[i].normal;
            var rigidBody = _contactPoints[i].otherCollider;
            if (normal.y > _contactThreshold) IsGrounded = true;
            if (normal.y < _contactThreshold) IsUpperContact = true;
            if (normal.x > _contactThreshold && rigidBody == null) IsRightContact = true;
            if (normal.x < -_contactThreshold && rigidBody == null) IsLeftContact = true;
            if (normal.z > _contactThreshold) IsForwardContact = true;
            if (normal.z < _contactThreshold) IsBackwardContact = true;
        }
    }
}
