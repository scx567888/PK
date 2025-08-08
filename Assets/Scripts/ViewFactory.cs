using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// 后期支持对象池
    /// </summary>
    public static class ViewFactory
    {
        
        private static GameObject redBossPrefab;
        private static GameObject redSoldierPrefab;
        private static GameObject blueBossPrefab;
        private static GameObject blueSoldierPrefab;
        
        private static bool isInit = false;

        public static void init()
        {
            if (isInit)
            {
                return;
            }

            redBossPrefab = Resources.Load<GameObject>("Prefabs/RedBoss");
            redSoldierPrefab = Resources.Load<GameObject>("Prefabs/RedSoldier");
            blueBossPrefab = Resources.Load<GameObject>("Prefabs/BlueBoss");
            blueSoldierPrefab = Resources.Load<GameObject>("Prefabs/BlueSoldier");
            
            isInit = true;
        }
        
        public static GameObject getRedBoss()
        {
            return GameObject.Instantiate(redBossPrefab);
        }
        
        public static GameObject getBlueBoss()
        {
            return GameObject.Instantiate(blueBossPrefab);
        }
        
        public static GameObject getRedSoldier()
        {
            return GameObject.Instantiate(redSoldierPrefab);
        }
        
        public static GameObject getBlueSoldier()
        {
            return GameObject.Instantiate(blueSoldierPrefab);
        }

        public static void destroyRedBoss(GameObject redBoss)
        {
            GameObject.Destroy(redBoss);
        }

        public static void destroyBlueBoss(GameObject blueBoss)
        {
            GameObject.Destroy(blueBoss);
        }

        public static void destroyRedSoldier(GameObject redSoldier)
        {
            GameObject.Destroy(redSoldier);
        }

        public static void destroyBlueSoldier(GameObject blueSoldier)
        {
            GameObject.Destroy(blueSoldier);
        }
        
    }
    
}