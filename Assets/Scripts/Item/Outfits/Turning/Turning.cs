using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Turning : Outfit
{
    public Turning(string name, string descritpion, int quantity, int force) : base(name, descritpion, quantity)
    {
        Force = force;
    }

    public int Force { get; set; }

    /// <summary>
    /// -1f is counter clockwise (left); 1f is clockwise (right)
    /// </summary>
    /// <param name="modifier"></param>
    public void Rotate(float modifier)
    {
        modifier = modifier > 0f ? Mathf.Min(modifier, 1f) : Mathf.Max(modifier, -1f);
        transform.GetComponent<Rigidbody2D>().AddTorque(Force * -modifier * 100 * Time.deltaTime, ForceMode2D.Impulse);
    }
    public bool RotateTowards(Vector3 dir)
    {
        Vector3 forwardVector = transform.transform.up;
        float angle = Vector3.Angle(forwardVector, dir);
        if (180 - angle > 2)
        {
            if (Vector3.Cross(forwardVector, dir).z <= 0)
            {
                transform.GetComponent<Turning>().Rotate(-1);
                return false;
            }
            else if (Vector3.Cross(forwardVector, dir).z > 0)
            {
                transform.GetComponent<Turning>().Rotate(1);
                return false;
            }
        }
        else
        {
            float angle2 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f; // Subtracting 90 to account for the difference in coordinate systems between Atan2 and Unity's rotation
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle2));
            transform.transform.SetPositionAndRotation(transform.transform.position, targetRotation);
            return true;
        }
        return true;
    }
}
