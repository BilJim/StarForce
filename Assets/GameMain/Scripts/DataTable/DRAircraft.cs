﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2019-01-24 21:44:02.165
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    /// <summary>
    /// 战机表。
    /// </summary>
    public class DRAircraft : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取战机编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取推进器编号。
        /// </summary>
        public int ThrusterId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取武器编号0。
        /// </summary>
        public int WeaponId0
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取武器编号1。
        /// </summary>
        public int WeaponId1
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取武器编号2。
        /// </summary>
        public int WeaponId2
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取装甲编号0。
        /// </summary>
        public int ArmorId0
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取装甲编号1。
        /// </summary>
        public int ArmorId1
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取装甲编号2。
        /// </summary>
        public int ArmorId2
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取死亡特效编号。
        /// </summary>
        public int DeadEffectId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取死亡声音编号。
        /// </summary>
        public int DeadSoundId
        {
            get;
            private set;
        }

        public override bool ParseDataRow(GameFrameworkSegment<string> dataRowSegment)
        {
            string[] text = dataRowSegment.Source.Substring(dataRowSegment.Offset, dataRowSegment.Length).Split('\t');
            int index = 0;
            index++;
            m_Id = int.Parse(text[index++]);
            index++;
            ThrusterId = int.Parse(text[index++]);
            WeaponId0 = int.Parse(text[index++]);
            WeaponId1 = int.Parse(text[index++]);
            WeaponId2 = int.Parse(text[index++]);
            ArmorId0 = int.Parse(text[index++]);
            ArmorId1 = int.Parse(text[index++]);
            ArmorId2 = int.Parse(text[index++]);
            DeadEffectId = int.Parse(text[index++]);
            DeadSoundId = int.Parse(text[index++]);

            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(GameFrameworkSegment<byte[]> dataRowSegment)
        {
            using (MemoryStream memoryStream = new MemoryStream(dataRowSegment.Source, false))
            {
                return ParseDataRow(new GameFrameworkSegment<Stream>(memoryStream, dataRowSegment.Offset, dataRowSegment.Length));
            }
        }

        public override bool ParseDataRow(GameFrameworkSegment<Stream> dataRowSegment)
        {
            Log.Warning("Not implemented ParseDataRow(GameFrameworkSegment<Stream>)");
            return false;
        }

        private KeyValuePair<int, int>[] m_WeaponId = null;

        public int GetWeaponId(int id)
        {
            foreach (KeyValuePair<int, int> i in m_WeaponId)
            {
                if (i.Key == id)
                {
                    return i.Value;
                }
            }

            throw new GameFrameworkException(Utility.Text.Format("GetWeaponId with invalid id '{0}'.", id.ToString()));
        }

        public int GetWeaponIdAt(int index)
        {
            if (index < 0 || index >= m_WeaponId.Length)
            {
                throw new GameFrameworkException(Utility.Text.Format("GetWeaponIdAt with invalid index '{0}'.", index.ToString()));
            }

            return m_WeaponId[index].Value;
        }

        private KeyValuePair<int, int>[] m_ArmorId = null;

        public int GetArmorId(int id)
        {
            foreach (KeyValuePair<int, int> i in m_ArmorId)
            {
                if (i.Key == id)
                {
                    return i.Value;
                }
            }

            throw new GameFrameworkException(Utility.Text.Format("GetArmorId with invalid id '{0}'.", id.ToString()));
        }

        public int GetArmorIdAt(int index)
        {
            if (index < 0 || index >= m_ArmorId.Length)
            {
                throw new GameFrameworkException(Utility.Text.Format("GetArmorIdAt with invalid index '{0}'.", index.ToString()));
            }

            return m_ArmorId[index].Value;
        }

        private void GeneratePropertyArray()
        {
            m_WeaponId = new KeyValuePair<int, int>[]
            {
                new KeyValuePair<int, int>(0, WeaponId0),
                new KeyValuePair<int, int>(1, WeaponId1),
                new KeyValuePair<int, int>(2, WeaponId2),
            };

            m_ArmorId = new KeyValuePair<int, int>[]
            {
                new KeyValuePair<int, int>(0, ArmorId0),
                new KeyValuePair<int, int>(1, ArmorId1),
                new KeyValuePair<int, int>(2, ArmorId2),
            };
        }
    }
}
