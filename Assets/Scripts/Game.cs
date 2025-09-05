using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game
    {

        public GameState state;

        public int soldierId;

        public List<Boss> redBossList;
        public List<Boss> blueBossList;
        public List<Soldier> redSoldierList;
        public List<Soldier> blueSoldierList;
        public readonly GameObject ground;
        private Mesh soldierMesh;
        private Material soldierMaterial;
        private Material redMat;
        private Material blueMat;

        public Game(GameObject ground)
        {
            this.ground = ground;
            this.redBossList = new List<Boss>();
            this.blueBossList = new List<Boss>();
            this.redSoldierList = new List<Soldier>();
            this.blueSoldierList = new List<Soldier>();
        }

        public void Start()
        {
            
            this.soldierMesh = Resources.GetBuiltinResource<Mesh>("Sphere.fbx");
            
            this.redMat = new Material(Shader.Find("Standard"));
            redMat.enableInstancing = true;
            redMat.renderQueue = 3000;
            redMat.color = Color.red;

            this.blueMat = new Material(Shader.Find("Standard"));
            blueMat.enableInstancing = true;
            blueMat.renderQueue = 3000;
            blueMat.color = Color.blue;
            
            state = GameState.PLAYING;
            redBossList.Add(new Boss(Camp.RED, this));
            for (int i = 0; i < 5000; i++)
            {
                blueSoldierList.Add(new Soldier(soldierId++, Camp.BLUE, SoldierType.NORMAL, this));
            }

            blueBossList.Add(new Boss(Camp.BLUE, this));
            for (int i = 0; i < 5000; i++)
            {
                redSoldierList.Add(new Soldier(soldierId++, Camp.RED, SoldierType.NORMAL, this));
            }
            Debug.Log($"Mesh: {soldierMesh}, RedMat: {redMat}, BlueMat: {blueMat}");
        }

        public void Update()
        {
            if (state == GameState.PLAYING)
            {
                Debug.Log("游戏运行中");
                UpdatePlaying();
            }
        }

        public void UpdatePlaying()
        {
            foreach (var boss in redBossList)
            {
                boss.Update();
            }
            
            foreach (var boss in blueBossList)
            {
                boss.Update();
            }
            
            foreach (var soldier in redSoldierList)
            {
                soldier.Update();
            }
            
            foreach (var soldier in blueSoldierList)
            {
                soldier.Update();
            }

            RenderSoldiers(redSoldierList,redMat);
            RenderSoldiers(blueSoldierList,blueMat);
        }
        
        
        private void RenderSoldiers(List<Soldier> soldiers, Material material)
        {
            float t0 = Time.realtimeSinceStartup;
            int maxBatch = 1023;
            for (int i = 0; i < soldiers.Count; i += maxBatch)
            {
                int batchCount = Mathf.Min(maxBatch, soldiers.Count - i);
                Matrix4x4[] matrices = new Matrix4x4[batchCount];
                for (int j = 0; j < batchCount; j++)
                {
                    matrices[j] = soldiers[i + j].GetMatrix();
                }
                Graphics.DrawMeshInstanced(soldierMesh, 0, material, matrices);
            }
            float t1 = Time.realtimeSinceStartup;
            Debug.Log($"RenderSoldiers {soldiers.Count} 用时 {(t1 - t0) * 1000f:F2} ms");
        }
    }
    
    
}