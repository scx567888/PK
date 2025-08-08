using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Utils{
    
        
        public static T RandomGet<T>(List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
        
        
        public static Vector3 getBossInitPosition(GameObject ground,Camp camp)
        {
            // 1. 获取地板的位置
            Vector3 groundPos = ground.transform.position;

            // 2. 获取地板的宽度（假设宽度是 x 轴方向）
            Renderer groundRenderer = ground.GetComponent<Renderer>();
            float groundWidth = groundRenderer.bounds.size.x;

            // 3. 计算左右两侧的位置（以地板中心为基准）
            // 这里偏移量可以根据需要调整，比如偏离地板边缘一点
            float offset = groundWidth / 2 - 2f; // 2f是额外距离

            Vector3 leftPos = new Vector3(groundPos.x - offset, groundPos.y, groundPos.z);
            Vector3 rightPos = new Vector3(groundPos.x + offset, groundPos.y, groundPos.z);

            // 4. 生成红色Boss在左边，蓝色Boss在右边
            if (camp==Camp.RED)
            {
                var redBoss =  leftPos;
                return redBoss;
            }
            else
            {
                var blueBoss = rightPos;
                return blueBoss;
            }
        }

        public static Vector3 getSoilderInitPosition(GameObject ground, Camp camp)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-3f, 3f),  // x 方向随机偏移
                0f,                     // y 不偏移（保持在地面上）
                Random.Range(-3f, 3f)   // z 方向随机偏移
            );

            Vector3 spawnPos = Vector3.zero + randomOffset;
             return spawnPos;    
        }
        
    }
}