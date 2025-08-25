using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    public int lightningLevel = 0;
    public int meteorLevel = 0;
    public int snowLevel = 0;
    public int auraLevel = 0;

    public Transform plexusaoe;
    public float plexusaoeTime = 5.0f;
    public float plexusaoePassTime = 0.0f;

    public Transform meteorsaoe;
    public float meteorsaoeTime = 10.0f;
    public float meteorsaoePassTime = 0.0f;

    public Transform snowaoe;
    public float snowaoeTime = 10.0f;
    public float snowaoePassTime = 0.0f;

    public void UpgradeLightning()
    {
        lightningLevel++; 
    }
    //=> lightningLevel++;
    public void UpgradeMeteor()
    {
        meteorLevel++;
    } //=> meteorLevel++;
    public void UpgradeBlizzard()
    {
        snowLevel++;
        
    } //=> snowLevel++;
    /*public void UpgradeLightningAura()
    {
        auraLevel++;
    } //=> auraLevel++;*/

    void Update()
    {
        if (snowLevel >= 1)
        {
            //얼음장판스폰
            Vector3 snowPosition = new Vector3(Random.Range(-14, 14), 0, Random.Range(14, -14));      

            if (snowaoePassTime >= snowaoeTime)
            {
                Instantiate(snowaoe, snowPosition, transform.rotation);
                snowaoePassTime = 0.0f;
            }
            else
            {
                snowaoePassTime += Time.deltaTime;
            }
            if (snowLevel >= 2)//레벨업당 쿨타임1초 감소
            {
                snowaoeTime = 8f;
            }
            if (snowLevel >= 3)
            {
                snowaoeTime = 6f;
            }
            if (snowLevel >= 4)
            {
                snowaoeTime = 4f;
            }
            if (snowLevel >= 5)
            {
                snowaoeTime = 2f;
            }
        }

        if (lightningLevel >= 1)
        {
            //번개스폰
            Vector3 lightningPosition = new Vector3(Random.Range(-16, 16), 0, Random.Range(16, -16));     

            if (plexusaoePassTime >= plexusaoeTime)
            {
                Instantiate(plexusaoe, lightningPosition, transform.rotation);
                plexusaoePassTime = 0.0f;
            }
            else
            {
                plexusaoePassTime += Time.deltaTime;
            }
            if (lightningLevel >= 2)//레벨업당 쿨타임1초 감소
            {
                plexusaoeTime = 4.0f;
            }
            if (lightningLevel >= 3)
            {
                plexusaoeTime = 3.0f;
            }
            if (lightningLevel >= 4)
            {
                plexusaoeTime = 2.0f;
            }
            if (lightningLevel >= 5)
            {
                plexusaoeTime = 1.0f;
            }
        }
        if (meteorLevel >= 1)
        {
            //메테오스폰
            Vector3 meteorPosition = new Vector3(Random.Range(-14, 14), 0, Random.Range(14, -14));

            if (meteorsaoePassTime >= meteorsaoeTime)
            {
                Instantiate(meteorsaoe, meteorPosition, transform.rotation);
                meteorsaoePassTime = 0.0f;
            }
            else
            {
                meteorsaoePassTime += Time.deltaTime;
            }
            if (meteorLevel >= 2)//레벨업당 쿨타임 감소
            {
                meteorsaoeTime = 9.0f;
            }
            if (meteorLevel >= 3)
            {
                meteorsaoeTime = 8.0f;
            }
            if (meteorLevel >= 4)
            {
                meteorsaoeTime = 7.0f;
            }
            if (meteorLevel >= 5)
            {
                meteorsaoeTime = 6.0f;
            }
        }
    }
}
