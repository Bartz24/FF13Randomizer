using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Parties
    {
        public static List<Party> parties = new List<Party>();

        #region Role/Member Definitions
        private static Role[] rolesCh1_2 = new Role[] { Role.None };
        private static Role[] rolesAll = new Role[] { Role.Commando, Role.Ravager, Role.Sentinel, Role.Synergist, Role.Saboteur, Role.Medic };

        private static Member LCh3 = new Member(Character.Lightning, Role.Commando, Role.Ravager);
        private static Member VCh3 = new Member(Character.Vanille, Role.Ravager, Role.Medic);
        private static Member SzCh3 = new Member(Character.Sazh, Role.Ravager);

        private static Member SzCh4 = new Member(Character.Sazh, Role.Ravager, Role.Synergist);

        private static Member LPrimary = new Member(Character.Lightning, Role.Commando, Role.Ravager, Role.Medic);
        private static Member SnPrimary = new Member(Character.Snow, Role.Commando, Role.Ravager, Role.Sentinel);
        private static Member SzPrimary = new Member(Character.Sazh, Role.Commando, Role.Ravager, Role.Synergist);
        private static Member VPrimary = new Member(Character.Vanille, Role.Ravager, Role.Saboteur, Role.Medic);
        private static Member HPrimary = new Member(Character.Hope, Role.Ravager, Role.Synergist, Role.Medic);
        private static Member FPrimary = new Member(Character.Fang, Role.Commando, Role.Sentinel, Role.Saboteur);
        #endregion

        #region Ch1-2
        public static Party Ch1_2LSz = new Party(0, false, new Member(Character.Lightning, rolesCh1_2), new Member(Character.Sazh, rolesCh1_2));
        public static Party Ch1_2Sn = new Party(0, false, new Member(Character.Snow, rolesCh1_2));
        public static Party Ch2VH = new Party(0, false, new Member(Character.Vanille, rolesCh1_2), new Member(Character.Hope, rolesCh1_2));
        public static Party Ch1_2SnVH = new Party(0, false, new Member(Character.Snow, rolesCh1_2), new Member(Character.Lightning, rolesCh1_2), new Member(Character.Sazh, rolesCh1_2));
        public static Party Ch2LSnSz = new Party(0, false, new Member(Character.Lightning, rolesCh1_2), new Member(Character.Snow, rolesCh1_2), new Member(Character.Sazh, rolesCh1_2));
        #endregion

        #region Ch3
        public static Party Ch3LSnV = new Party(1, false, LCh3, SnPrimary, VCh3);
        public static Party Ch3LSzV = new Party(1, false, LCh3, SzCh3, VCh3);
        public static Party Ch3Sn = new Party(1, false, SnPrimary);
        #endregion

        #region Ch4
        public static Party Ch4LSzV = new Party(2, false, LCh3, SzCh4, VPrimary);
        public static Party Ch4St2LH = new Party(2, false, LCh3, HPrimary);
        public static Party Ch4St2SzV = new Party(2, false, SzCh4, VPrimary);
        public static Party Ch4SzVH = new Party(2, false, SzCh4, VPrimary, HPrimary);
        public static Party Ch4SzLV = new Party(2, false, SzCh4, LCh3, VPrimary);
        public static Party Ch4LH = new Party(3, false, LPrimary, HPrimary);
        public static Party Ch4SzV = new Party(3, false, SzPrimary, VPrimary);
        #endregion

        #region Ch5
        public static Party Ch5HL = new Party(3, false, HPrimary, LPrimary);
        public static Party Ch5LH = new Party(3, false, LPrimary, HPrimary);
        #endregion

        #region Ch6
        public static Party Ch6VSz = new Party(4, false, VPrimary, SzPrimary);
        #endregion

        #region Ch7
        public static Party Ch7LH = new Party(5, false, LPrimary, HPrimary);
        public static Party Ch7Sn = new Party(5, false, SnPrimary);
        public static Party Ch7SnH = new Party(5, false, SnPrimary, HPrimary);
        public static Party Ch7FL = new Party(5, false, FPrimary, LPrimary);
        public static Party Ch7FLH = new Party(5, false, FPrimary, LPrimary, HPrimary);
        public static Party Ch7LFH = new Party(5, false, LPrimary, FPrimary, HPrimary);
        #endregion

        #region Ch8
        public static Party Ch8SzV = new Party(6, false, SzPrimary, VPrimary);
        #endregion

        #region Ch9
        public static Party Ch9LFH = new Party(6, false, LPrimary, FPrimary, HPrimary);
        public static Party Ch9SzV = new Party(6, false, SzPrimary, VPrimary);
        public static Party Ch9All = new Party(6, false, LPrimary, FPrimary, HPrimary, SzPrimary, VPrimary, SnPrimary);
        #endregion

        #region Ch10+
        public static Party Ch10Pre2nd = new Party(7, false, LPrimary, FPrimary, HPrimary, SzPrimary, VPrimary, SnPrimary);
        public static Party Ch10PreCid = new Party(7);
        public static Party Ch10_11 = new Party(8);
        public static Party Ch10FLV = new Party(8, false, new Member(Character.Fang, rolesAll), new Member(Character.Lightning, rolesAll), new Member(Character.Vanille, rolesAll));
        public static Party Ch11NoH = new Party(8, Character.Hope);
        public static Party Ch11HLF = new Party(8, false, new Member(Character.Hope, rolesAll), new Member(Character.Lightning, rolesAll), new Member(Character.Fang, rolesAll));
        public static Party Ch11VF = new Party(8, false, new Member(Character.Vanille, rolesAll), new Member(Character.Fang, rolesAll));
        public static Party Ch12_13 = new Party(9);
        public static Party Ch12LSnV = new Party(9, false, new Member(Character.Lightning, rolesAll), new Member(Character.Snow, rolesAll), new Member(Character.Vanille, rolesAll));
        public static Party Ch13Post = new Party(10);
        #endregion
    }
}
