﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query09_GetCustomersGroupedByYearTests
    {
        private static Hotel hotel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            hotel = HotelBuilder.CreateHotel();
        }

        [TestMethod]
        public void Test()
        {
            List<KeyValuePair<int, int[]>> expectedCustomerIds = new List<KeyValuePair<int, int[]>>
            {
                new KeyValuePair<int, int[]>(2018, new[]
                {
                    472, 690, 979, 68, 578, 1095, 275, 1042, 1382, 883, 689, 704, 1205, 793, 489, 664, 95, 905, 619, 119, 571, 882, 977, 46, 230, 785, 1269, 807, 1115, 77, 723, 929, 4, 935, 610, 155, 1090, 790, 926, 1075
                }),
                new KeyValuePair<int, int[]>(2017, new[]
                {
                    1141, 354, 847, 118, 126, 389, 289, 344, 908, 997, 831, 460, 548, 32, 504, 31, 221, 928, 1334, 549, 1374, 147, 540, 124, 648, 547, 917, 731, 1330, 1005, 490, 621, 733, 244, 193, 1359, 1094, 1110, 419, 1091, 1227, 251, 855, 835, 53, 839, 1088, 1032, 1311, 1212, 496, 362, 236, 441, 443, 924, 823, 776, 501, 62, 1370, 660, 663, 307, 875, 208, 818, 514, 972, 878, 777, 293, 1273, 299, 58, 1026, 961, 849, 821, 93, 207, 398, 984, 558, 536, 525, 1019, 102, 1121, 433, 592, 273, 268,
                    425, 754, 498, 819, 1286, 1239, 1228, 142, 272, 721, 1229, 677, 92, 996, 1105, 848, 868, 80, 1214, 17, 452, 586, 1393, 1030, 1070, 963, 543, 993, 805, 1108, 335, 1195, 769, 404, 530, 42, 570, 171, 73, 719, 1301, 1208, 1397, 1217, 483, 401, 556, 209, 1068, 20, 1118, 1169, 1168, 269, 709, 328, 196, 1371, 966, 1191, 1201, 1366, 947, 256, 1232, 1213, 1063, 1240, 1343, 397, 1284
                }),
                new KeyValuePair<int, int[]>(2016, new[]
                {
                    694, 1309, 992, 955, 522, 964, 178, 943, 500, 434, 1134, 1147, 1362, 324, 7, 420, 373, 703, 1145, 737, 1274, 627, 1367, 1187, 1154, 915, 554, 551, 291, 815, 1158, 1357, 290, 916, 845, 535, 865, 634, 164, 832, 596, 453, 280, 350, 312, 763, 713, 457, 565, 86, 33, 437, 5, 1253, 104, 1316, 235, 1097, 804, 410, 978, 1160, 198, 470, 1112, 351, 716, 580, 537, 445, 314, 1050, 1247, 1146, 1251, 661, 1338, 973, 939, 48, 1076, 1307, 1157, 836, 538, 417, 990, 1333, 615, 439, 752, 1152,
                    692, 387, 575, 599, 1226, 1380, 156, 303, 446, 971, 1039, 1010, 301, 222, 129, 965, 449, 152, 1356, 476, 1133, 1172, 50, 532, 285, 21, 581, 88, 1256, 900, 163, 545, 24, 317, 114, 159, 1055, 755, 1035, 913, 329, 517, 320, 149, 576, 1072, 1165, 788, 702, 1207, 1263, 41, 487, 83, 1135, 243, 999, 680, 1352, 1276, 340, 937, 305, 1190, 1223, 1159, 1391, 1304, 1197, 246, 796, 941, 1054, 1218
                }),
                new KeyValuePair<int, int[]>(2015, new[]
                {
                    1250, 1104, 418, 353, 81, 797, 435, 727, 857, 909, 886, 577, 1053, 1322, 396, 282, 411, 40, 491, 407, 572, 1368, 1125, 698, 30, 1281, 1043, 897, 174, 944, 903, 616, 382, 902, 67, 1028, 822, 416, 892, 352, 736, 242, 424, 153, 1151, 66, 112, 991, 521, 96, 427, 1285, 1389, 683, 1081, 934, 833, 477, 1313, 1399, 1045, 355, 803, 133, 1059, 695, 1243, 775, 1261, 1260, 1061, 192, 503, 765, 497, 383, 632, 224, 774, 629, 953, 409, 553, 871, 644, 486, 15, 574, 110, 1183, 1302, 1119,
                    1041, 1164, 667, 440, 125, 1254, 363, 946, 658, 394, 1033, 1174, 281, 431, 212, 884, 529, 679, 922, 22, 766, 511, 179, 1180, 65, 950, 938, 168, 502, 1211, 1120, 729, 650, 274, 471, 1129, 1336, 1100, 137, 591, 1093, 1140, 227, 1048, 76, 791, 1021, 356, 812, 374, 587, 113, 864, 403, 108, 701, 647, 426, 29, 753, 180, 200, 1290, 1283, 1215, 654, 759, 85, 54, 1262, 422, 637, 1058, 1353, 751, 1386, 1350, 162, 214, 327, 976, 840, 1184, 1128, 1077, 1196, 1375, 918, 1185, 1392, 962
                }),
                new KeyValuePair<int, int[]>(2014, new[]
                {
                    1179, 925, 1153, 817, 674, 395, 259, 932, 60, 899, 606, 276, 1299, 331, 958, 820, 732, 206, 266, 1, 254, 852, 234, 1086, 912, 1259, 636, 370, 566, 1265, 1292, 1252, 1365, 760, 888, 241, 158, 550, 26, 604, 186, 185, 233, 792, 456, 618, 1052, 945, 826, 245, 633, 295, 1377, 1034, 856, 1360, 148, 467, 625, 837, 1349, 265, 1241, 479, 263, 652, 311, 1079, 100, 653, 414, 607, 552, 358, 385, 429, 450, 838, 851, 194, 368, 1189, 1297, 1084, 267, 35, 111, 154, 761, 1178, 767, 1173,
                    1341, 509, 70, 239, 195, 308, 78, 18, 316, 1310, 1001, 1175, 499, 199, 614, 582, 413, 488, 512, 800, 954, 1025, 1022, 135, 743, 475, 1031, 458, 1080, 542, 1171, 1242, 960, 1216, 898, 1036, 710, 1067, 160, 36, 59, 423, 1347, 89, 145, 1182, 1139, 1092, 438, 927, 13, 641, 182, 880, 1074, 250, 478, 1296, 1344, 1234, 1314, 190, 1096, 1264, 1166, 61, 780, 161, 579, 1078, 844, 1176, 1388, 1233, 375, 869
                }),
                new KeyValuePair<int, int[]>(2013, new[]
                {
                    177, 1272, 730, 176, 687, 23, 601, 12, 84, 603, 988, 686, 1255, 1378, 294, 1395, 1038, 1132, 481, 1106, 1087, 564, 144, 867, 1202, 459, 131, 330, 507, 1249, 1376, 1040, 519, 465, 1016, 1258, 1082, 531, 668, 1017, 34, 858, 609, 894, 122, 360, 611, 893, 136, 1351, 995, 986, 219, 408, 673, 103, 534, 620, 881, 181, 879, 127, 985, 693, 930, 872, 786, 757, 801, 557, 444, 364, 97, 1069, 630, 639, 911, 63, 3, 874, 388, 1300, 1109, 262, 508, 569, 238, 559, 19, 885, 296, 1248, 806,
                    494, 1062, 367, 987, 1049, 1237, 1271, 203, 506, 638, 28, 907, 706, 555, 1098, 371, 1066, 622, 720, 1012, 345, 738, 890, 811, 981, 1111, 361, 302, 366, 132, 451, 237, 121, 563, 628, 82, 1355, 1143, 959, 287, 600, 1060, 1235, 45, 336, 715, 1312, 1027, 1002, 1162, 814, 333, 270, 1015, 758, 1163, 1007, 223, 784, 1116, 1192, 1287, 1384, 348, 1011, 1257, 1046, 1064
                }),
                new KeyValuePair<int, int[]>(2012, new[]
                {
                    1186, 585, 197, 561, 1155, 711, 608, 421, 799, 134, 495, 768, 877, 326, 346, 655, 1210, 298, 1073, 527, 1329, 657, 1167, 191, 1305, 47, 699, 252, 412, 742, 642, 746, 1379, 951, 1361, 666, 347, 447, 57, 887, 933, 772, 215, 226, 1308, 1047, 866, 286, 931, 1326, 405, 94, 201, 789, 79, 1122, 1335, 1282, 523, 524, 914, 665, 415, 854, 98, 645, 359, 225, 464, 123, 167, 390, 105, 952, 292, 544, 1295, 1398, 1023, 1318, 974, 165, 300, 910, 809, 589, 376, 725, 493, 309, 1020, 25, 101,
                    378, 1288, 342, 669, 1126, 605, 861, 343, 1324, 1267, 834, 27, 808, 473, 771, 635, 151, 1298, 1144, 643, 602, 172, 1136, 474, 271, 722, 469, 485, 143, 860, 1130, 649, 781, 684, 956, 782, 700, 173, 708, 372, 87, 533, 613, 513, 515, 919, 747, 72, 970, 739, 69, 393, 1006, 1293, 1270, 1315, 349, 1244, 297, 480, 1051, 705, 921, 889, 455, 71, 593, 255, 1137, 1394, 1396, 1013, 516, 37, 1199, 1138, 1114, 211, 43, 466, 1224, 253, 1236, 1003, 217, 923, 384
                }),
                new KeyValuePair<int, int[]>(2011, new[]
                {
                    14, 623, 980, 712, 967, 1107, 646, 204, 651, 325, 10, 717, 640, 681, 247, 745, 1372, 560, 859, 1345, 969, 210, 339, 813, 1230, 146, 313, 863, 779, 482, 685, 773, 1325, 377, 150, 595, 1124, 1275, 998, 187, 1387, 505, 139, 1156, 318, 697, 38, 1102, 130, 728, 904, 1291, 975, 454, 484, 175, 828, 1381, 1268, 594, 957, 1161, 612, 841, 228, 528, 920, 240, 386, 824, 853, 321, 691, 1280, 862, 520, 428, 365, 802, 682, 783, 99, 850, 1390, 1099, 707, 140, 218, 106, 248, 261, 1083, 1369,
                    778, 546, 380, 617, 279, 597, 310, 562, 688, 1103, 1203, 843, 306, 726, 1200, 315, 696, 51, 1385, 659, 1056, 229, 1004, 1219, 1320, 1346, 968, 584, 369, 1303, 1188, 1294, 741, 1029, 1220, 1194, 675, 1400, 1245, 827, 1278, 541, 1170, 829, 184, 260, 846, 157, 436, 49, 1127, 1327, 1348, 1238, 1266, 588, 468, 1024, 128, 116, 381, 1101, 1123, 1358, 189, 1009, 568, 357, 983, 798, 141, 90, 770, 1065, 1332, 1363, 138, 842, 1328, 74, 1342, 1319, 430, 304, 284, 264, 1085
                }),
                new KeyValuePair<int, int[]>(2010, new[]
                {
                    341, 764, 8, 319, 402, 115, 1306, 462, 1339, 323, 794, 461, 671, 1340, 1181, 598, 942, 1177, 120, 166, 656, 1204, 662, 1117, 1231, 91, 432, 213, 631, 257, 1323, 936, 216, 188, 492, 1071, 1000, 55, 748, 1225, 1131, 1221, 1198, 949, 873, 109, 756, 52, 107, 583, 1279, 830, 567, 277, 901, 1337, 1044, 231, 334, 1014, 1354, 994, 526, 989, 724, 232, 510, 392, 332, 6, 391, 400, 718, 399, 734, 1142, 573, 982, 676, 895, 288, 1089, 1289, 1222, 1331, 442, 735, 670, 169, 1209, 56, 762,
                    787, 64, 1373, 406, 258, 518, 714, 891, 220, 183, 672, 9, 749, 940, 75, 750, 825, 2, 816, 202, 44, 810, 170, 896, 1008, 283, 590, 740, 1037, 1018, 1383, 39, 1057, 249, 322, 1321, 205, 11, 278, 337, 463, 624, 1148, 1246, 1113, 906, 338, 16, 1206, 948, 678, 626, 379, 744, 117, 1317, 1364, 448, 1150, 1149, 870, 795, 876, 539, 1277, 1193
                })
            };
            PerformTest(expectedCustomerIds);
        }

        private static void PerformTest(IReadOnlyList<KeyValuePair<int, int[]>> expectedCustomerIds)
        {
            List<KeyValuePair<int, Customer[]>> actualCustomers = hotel.GetCustomersGroupedByYear();

            int[] expectedYears = expectedCustomerIds
                .Select(x => x.Key)
                .ToArray();

            int[] actualYears = actualCustomers
                .Select(x => x.Key)
                .ToArray();

            Trace.WriteLine("Expected years: " + string.Join(", ", expectedYears));
            Trace.WriteLine("Actual years:   " + string.Join(", ", actualYears));

            CollectionAssert.AreEqual(expectedYears, actualYears);

            for (int i = 0; i < actualCustomers.Count; i++)
            {
                (int actualYear, Customer[] actualCustomersPerYear) = actualCustomers[i];
                List<int> actualCustomerIdsPerYear = actualCustomersPerYear
                    .Select(x => x.Id)
                    .ToList();

                (int expectedYear, int[] expectedCustomerIdsPerYear) = expectedCustomerIds[i];

                Trace.WriteLine(string.Empty);
                Trace.WriteLine($"Years: actual = {actualYear}; expected = {expectedYear}");
                Trace.WriteLine(string.Empty);

                Trace.WriteLine("Expected customer ids: " + string.Join(", ", expectedCustomerIdsPerYear));
                Trace.WriteLine(string.Empty);
                Trace.WriteLine("Actual customer ids:   " + string.Join(", ", actualCustomerIdsPerYear));

                Assert.AreEqual(expectedYear, actualYear);
                CollectionAssert.AreEqual(expectedCustomerIdsPerYear, actualCustomerIdsPerYear);
            }
        }
    }
}