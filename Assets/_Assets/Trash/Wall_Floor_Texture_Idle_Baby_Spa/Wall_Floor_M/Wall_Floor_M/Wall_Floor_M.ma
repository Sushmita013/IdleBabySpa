//Maya ASCII 2018ff08 scene
//Name: Wall_Floor_M.ma
//Last modified: Thu, Sep 14, 2023 03:58:27 PM
//Codeset: 1252
requires maya "2018ff08";
requires "mtoa" "3.0.0.2";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201804211841-f3d65dda2a";
fileInfo "osv" "Microsoft Windows 8 Business Edition, 64-bit  (Build 9200)\n";
createNode transform -s -n "persp";
	rename -uid "428EDBE4-489A-84F1-BC8C-929AF65D6B63";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 739.67675236117873 516.22458523963633 433.042499960003 ;
	setAttr ".r" -type "double3" -29.338353693260061 -1377.2003371098203 -3.4790337927717253e-15 ;
	setAttr ".rp" -type "double3" 2.2737367544323206e-13 -2.8421709430404007e-14 -9.0949470177292824e-13 ;
	setAttr ".rpt" -type "double3" 6.1256090706636687e-13 -3.7514828608009974e-13 8.0305997890197887e-13 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "52C62802-4C5F-555C-7806-22A97F288585";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999979;
	setAttr ".ncp" 2;
	setAttr ".fcp" 10000000000;
	setAttr ".coi" 1007.2553079599741;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 267.06183732700867 50.000007629394496 -29.240553872426347 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
	setAttr ".ai_translator" -type "string" "perspective";
createNode transform -s -n "top";
	rename -uid "9CD29F1C-46B4-89A8-396E-5F8BDF0EB9D7";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 366.48108286065894 1996.8150129991757 27.631414848534803 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "B86D6CD8-4FC5-6AF0-A9D1-3CAAF3C9ADA8";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1946.8150129991757;
	setAttr ".ow" 2133.4230547531274;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".tp" -type "double3" 701.6695600321284 50 58.731376647949219 ;
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "3BF5F8A9-434E-8A74-FB15-4E92A7E24073";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -2.1686655600205995e-06 50.000007629394531 1080.5896822125364 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "525110CB-4527-5013-FBBF-36932995EE0E";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1080.5896840868245;
	setAttr ".ow" 191.23586341887764;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".tp" -type "double3" -2.1686655600205995e-06 50.000007629394531 -1.8742880456557032e-06 ;
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "D2C2B562-4A52-299A-F236-5884E6E31BB5";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1150.2970428929514 50.000007629394531 -1.8742877898603183e-06 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "80358988-49F7-E00C-14C9-83ADC48718C3";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1150.2970450616169;
	setAttr ".ow" 244.40213762525022;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".tp" -type "double3" -2.1686655600205995e-06 50.000007629394531 -1.8742880456557032e-06 ;
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -n "Gate_M";
	rename -uid "81237F01-4182-9853-BA73-15B5B081FB1A";
	setAttr ".t" -type "double3" 0 0 447.94455589060954 ;
	setAttr ".rp" -type "double3" 0 50 0 ;
	setAttr ".sp" -type "double3" 0 50 0 ;
createNode mesh -n "Gate_MShape" -p "Gate_M";
	rename -uid "1413B03C-49EB-BF03-D8B1-14BC3B8FA110";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.048724133521318436 0.61556583642959595 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 8 ".uvst[0].uvsp[0:7]" -type "float2" 0.051055089 0.61085188
		 0.047760591 0.61027575 0.047089987 0.61136061 0.050318345 0.611911 0.04536714 0.63288569
		 0.048810109 0.63319981 0.046036787 0.63226545 0.049555182 0.63259506;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcol" yes;
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -6.81799316 0 7.40960693 -6.81799316 0 -7.40960693
		 6.81799316 0 7.40960693 6.81799316 0 -7.40960693 6.81799316 100 7.40960693 6.81799316 100 -7.40960693
		 -6.81799316 100 7.40960693 -6.81799316 100 -7.40960693;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 7 1 0 6 0 0;
	setAttr -s 5 -ch 20 ".fc[0:4]" -type "polyFaces" 
		f 4 -3 -7 1 7
		mu 0 4 4 5 3 2
		f 4 2 9 -4 -9
		mu 0 4 5 4 6 7
		f 4 3 10 -1 -12
		mu 0 4 7 6 1 0
		f 4 -11 -10 -8 -6
		mu 0 4 1 6 4 2
		f 4 8 11 4 6
		mu 0 4 5 7 0 3;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "Wall_Big_M";
	rename -uid "42A3D0B2-498F-A343-3597-C8ADF8FA1974";
	setAttr ".rp" -type "double3" 0 50.000015258789063 -7.62939453125e-06 ;
	setAttr ".sp" -type "double3" 0 50.000015258789063 -7.62939453125e-06 ;
createNode mesh -n "Wall_Big_MShape" -p "Wall_Big_M";
	rename -uid "3DA79824-4471-BB03-5B48-B9924C40C68C";
	setAttr -k off ".v";
	setAttr -s 2 ".iog[0].og";
	setAttr ".iog[0].og[1].gcl" -type "componentList" 2 "f[0:1]" "f[3:4]";
	setAttr ".iog[0].og[2].gcl" -type "componentList" 1 "f[2]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.50000010430812836 0.38922867178916931 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 16 ".uvst[0].uvsp[0:15]" -type "float2" 1.37424207 0.99840862
		 -0.3742421 0.9984079 -0.37424198 0.60985577 1.37424254 0.60985649 1.3737359 0.38787019
		 -0.37373585 0.38787043 -0.37373585 -0.00045681 1.3737359 -0.00045722723 2.6473155
		 0.55702102 -1.6473155 0.55702144 -1.64731598 0.44297925 2.64731598 0.44297877 1.42722476
		 0.99840862 1.42722523 0.60985684 -0.42722526 0.99840802 -0.42722464 0.60985577;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  6.81802368 1.5258789e-05 -200 6.81799316 1.5258789e-05 199.99998474
		 -6.81799316 1.5258789e-05 -200 -6.81802368 1.5258789e-05 199.99998474 -6.81799316 100.000015258789 -200
		 -6.81802368 100.000015258789 199.99998474 6.81802368 100.000015258789 -200 6.81799316 100.000015258789 199.99998474;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 7 1 0 6 0 0;
	setAttr -s 5 -ch 20 ".fc[0:4]" -type "polyFaces" 
		f 4 -3 -7 1 7
		mu 0 4 0 1 2 3
		f 4 2 9 -4 -9
		mu 0 4 8 9 10 11
		f 4 3 10 -1 -12
		mu 0 4 4 5 6 7
		f 4 -11 -10 -8 -6
		mu 0 4 13 12 0 3
		f 4 8 11 4 6
		mu 0 4 1 14 15 2;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode mesh -n "polySurfaceShape2" -p "Wall_Big_M";
	rename -uid "8254BD9C-4939-B8C0-11B6-0EB62509BF66";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.44432052969932556 0.76959627866744995 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 48 ".uvst[0].uvsp[0:47]" -type "float2" 0.36768341 0.61837059
		 0.3891075 0.6181494 0.3891142 0.61879861 0.36769009 0.61901981 0.24418479 0.92693377
		 0.26843131 0.9272477 0.26802412 0.92769253 0.24400701 0.92751431 0.61315155 0.38683438
		 0.62091517 0.38678294 0.29790843 0.86329007 0.27916119 0.86347282 0.27913725 0.86101943
		 0.29788446 0.86083663 0.36801004 0.62900305 0.3795318 0.62908202 0.62091267 0.38640594
		 0.37953347 0.62883651 0.36801159 0.6287576 0.61001408 0.68610382 0.29845256 0.86083108
		 0.29847652 0.86328447 0.27859309 0.86347836 0.27856916 0.86102509 0.278566 0.8607015
		 0.27913409 0.86069602 0.29788136 0.86051315 0.29844946 0.86050761 0.26706427 0.91493344
		 0.2463516 0.92733985 0.24629077 0.92790365 0.26707077 0.91555691 0.6101023 0.67467165
		 0.5528332 0.67422986 0.55274498 0.68566209 0.5528028 0.67816746 0.6133734 0.38683292
		 0.6133709 0.38645595 0.62069076 0.38640743 0.62069333 0.38678443 0.6100719 0.67860931
		 0.61314905 0.38645738 0.36833918 0.62900531 0.36834085 0.6287598 0.37920433 0.62883425
		 0.3792026 0.62907982 0.61007953 0.67762125 0.55281043 0.6771794;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 20 ".vt[0:19]"  399.93270874 0 -100.034645081 399.93267822 0 349.96539307
		 386.29669189 0 -100.034645081 386.29666138 0 349.96536255 386.29669189 100 -100.034645081
		 386.29666138 100 349.96536255 399.93270874 100 -100.034645081 399.93267822 100 349.96539307
		 399.93267822 33.34619522 349.96539307 399.93270874 33.34619522 -100.034645081 386.29669189 33.34619522 -100.034645081
		 386.29666138 33.34619522 349.96536255 399.93267822 41.1100502 349.96539307 399.93270874 41.1100502 -100.034645081
		 386.29669189 41.1100502 -100.034645081 386.29666138 41.1100502 349.96536255 399.93267822 10.16943359 349.96539307
		 399.93270874 10.16943359 -100.034645081 386.29669189 10.16943359 -100.034645081 386.29666138 10.16943359 349.96536255;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 18 0
		 3 19 0 4 6 0 5 7 0 7 12 0 8 16 0 9 17 0 8 9 1 10 14 0 9 10 1 11 15 0 10 11 1 11 8 1
		 6 13 0 12 8 0 13 9 0 12 13 1 14 4 0 13 14 1 15 5 0 14 15 1 15 12 1 16 1 0 17 0 0
		 16 17 1 18 10 0 17 18 1 19 11 0 18 19 1 19 16 1;
	setAttr -s 18 -ch 72 ".fc[0:17]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 2 3
		f 4 -3 -24 26 25
		mu 0 4 10 11 12 13
		f 4 2 9 -4 -9
		mu 0 4 4 5 6 7
		f 4 3 10 22 -20
		mu 0 4 19 34 35 40
		f 4 27 -11 -10 -26
		mu 0 4 13 20 21 10
		f 4 8 19 24 23
		mu 0 4 11 22 23 12
		f 4 -14 11 30 -13
		mu 0 4 46 47 33 32
		f 4 -16 12 32 31
		mu 0 4 36 8 41 37
		f 4 34 33 -18 -32
		mu 0 4 37 38 39 36
		f 4 35 -12 -19 -34
		mu 0 4 38 16 9 39
		f 4 -23 20 13 -22
		mu 0 4 40 35 47 46
		f 4 -25 21 15 14
		mu 0 4 12 23 24 25
		f 4 -27 -15 17 16
		mu 0 4 13 12 25 26
		f 4 -21 -28 -17 18
		mu 0 4 27 20 13 26
		f 4 -31 28 -1 -30
		mu 0 4 31 30 29 28
		f 4 -33 29 4 6
		mu 0 4 42 14 18 43
		f 4 1 7 -35 -7
		mu 0 4 43 44 45 42
		f 4 -29 -36 -8 -6
		mu 0 4 17 15 45 44;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "Floor_M";
	rename -uid "B945B18D-4509-336D-B4D3-8BB91B149908";
	setAttr ".v" no;
createNode mesh -n "Floor_MShape" -p "Floor_M";
	rename -uid "82DC1287-41A3-C91B-75FE-32BFBDB0DA67";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.49896037578582764 0.49647189676761627 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 4 ".uvst[0].uvsp[0:3]" -type "float2" 0.0028300881 0.99647182
		 0.002830267 -0.0035280883 0.99509048 0.99647188 0.99509066 -0.0035279989;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 4 ".pt[0:3]" -type "float3"  1.2106018 0 -7.6293945e-06 
		-1.2106171 0 -7.6293945e-06 1.2106018 0 -7.6293945e-06 -1.2106171 0 -7.6293945e-06;
	setAttr -s 4 ".vt[0:3]"  -326.042144775 -7.1835584e-14 323.51870728
		 326.042144775 -7.1835584e-14 323.51870728 -326.042144775 7.1835584e-14 -323.51870728
		 326.042144775 7.1835584e-14 -323.51870728;
	setAttr -s 4 ".ed[0:3]"  0 1 0 0 2 0 1 3 0 2 3 0;
	setAttr -ch 4 ".fc[0]" -type "polyFaces" 
		f 4 0 2 -4 -2
		mu 0 4 0 1 3 2;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "Inide_Wall";
	rename -uid "77F70390-45A8-380E-7B53-89BC9537463E";
	setAttr ".t" -type "double3" 0 0 323.60342480533797 ;
	setAttr ".rp" -type "double3" 0 50 0 ;
	setAttr ".sp" -type "double3" 0 50 0 ;
createNode mesh -n "Inide_WallShape" -p "Inide_Wall";
	rename -uid "2911ED9C-40B5-6E81-A7C4-60AD6B2F57D5";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.35349339246749878 0.49926400184631348 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 16 ".uvst[0].uvsp[0:15]" -type "float2" 0.79223287 0.38915372
		 0.20776704 0.38915372 0.20776728 -0.0004901886 0.79223287 -0.00049006939 0.79223287
		 0.60937452 0.79223299 0.99901819 0.20776701 0.99901843 0.20776704 0.6093744 -0.13837819
		 0.44196689 1.13837814 0.44196701 1.13837814 0.55803287 -0.13837826 0.55803287 0.15463489
		 0.38915372 0.15463489 -0.0004901886 0.84536499 -0.00049042702 0.84536505 0.38915396;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcol" yes;
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  242.60413 0 -0.52229309 242.60413 
		0 -0.52229309 242.60413 0 -0.52229309 242.60413 0 -0.52229309 242.60413 0 49.477676 
		242.60413 0 49.477676 242.60413 0 49.477676 242.60413 0 49.477676;
	setAttr -s 8 ".vt[0:7]"  -249.42214966 0 -99.47770691 -235.78610229 0 -99.47770691
		 -235.78610229 100 -99.47770691 -249.42214966 100 -99.47770691 -235.78610229 100 50.52232361
		 -249.42214966 100 50.52232361 -249.42214966 0 50.52232361 -235.78610229 0 50.52232361;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 3 0 0 1 2 0 4 2 0 5 3 0 4 5 0
		 6 0 0 5 6 0 7 1 0 6 7 0 7 4 0;
	setAttr -s 5 -ch 20 ".fc[0:4]" -type "polyFaces" 
		f 4 -3 -2 -4 -1
		mu 0 4 2 1 12 13
		f 4 4 1 -6 -7
		mu 0 4 8 9 10 11
		f 4 5 2 -8 -9
		mu 0 4 0 1 2 3
		f 4 3 -5 -12 9
		mu 0 4 4 5 6 7
		f 4 11 6 8 10
		mu 0 4 14 15 0 3;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode mesh -n "polySurfaceShape4" -p "Inide_Wall";
	rename -uid "138CC260-48E6-2287-5A66-28A765854EB1";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.43697290122509003 0.76654237508773804 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 55 ".uvst[0].uvsp[0:54]" -type "float2" 0.29776794 0.86783218
		 0.27519843 0.86738169 0.26818699 0.91510719 0.24559501 0.91524923 0.36733931 0.61300594
		 0.36734846 0.61363935 0.62713325 0.38042313 0.61800158 0.38042071 -1.66699433 -0.7098726
		 -1.61481202 -0.68557626 0.24558204 0.91319543 0.26817405 0.91305339 0.27511388 0.8716194
		 0.61800134 0.38109553 0.36649913 0.61365163 -0.82532138 -1.036859035 -0.77993125
		 -0.99895811 0.38687459 0.61272383 0.61760426 0.38109541 0.27413258 0.87159985 0.27520958
		 0.8668229 0.29777911 0.86727345 0.28599256 0.8675971 0.28590798 0.87183481 0.28600371
		 0.86703831 0.28697383 0.86761665 0.28698498 0.86705804 0.28688926 0.87185442 0.27421716
		 0.86736214 0.29768336 0.87206995 0.27422833 0.86680329 0.62236887 0.38042188 0.62236869
		 0.38109669 0.62276572 0.38109678 0.6227659 0.38042197 0.61760449 0.38042063 0.62713313
		 0.38109794 0.37668228 0.61287099 0.37669143 0.61350441 0.37754077 0.61349213 0.37753162
		 0.61285865 0.36648998 0.61301816 0.38688374 0.61335713 0.59972864 0.66525257 0.59990901
		 0.68421257 0.55161536 0.684672 0.55143499 0.66571194 0.59970486 0.66275281 0.55141121
		 0.6632123 0.59963387 0.65529096 0.55134022 0.65575039 0.2690962 0.92225283 0.26910013
		 0.92390311 0.24475871 0.92396277 0.24475466 0.92231256;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcol" yes;
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 20 ".pt[0:19]" -type "float3"  -635.15692 0 -99.718155 -621.52087 
		0 -113.35419 -621.52087 0 -113.35419 -635.15692 0 -99.718155 -635.15692 0 -99.718155 
		-621.52087 0 -113.35419 -635.15692 0 -99.718155 -621.52087 0 -113.35419 -635.15692 
		0 -99.718155 -621.52087 0 -113.35419 -471.52084 0 36.645844 -485.15689 0 50.281876 
		-485.15689 0 50.281876 -485.15689 0 50.281876 -485.15689 0 50.281876 -485.15689 0 
		50.281876 -471.52084 0 36.645844 -471.52084 0 36.645844 -471.52084 0 36.645844 -471.52084 
		0 36.645844;
	setAttr -s 20 ".vt[0:19]"  385.73477173 0 0.240448 385.73477173 0 13.8764801
		 385.73477173 100 13.8764801 385.73477173 100 0.240448 385.73477173 33.34619522 0.240448
		 385.73477173 33.34619522 13.8764801 385.73477173 41.1100502 0.240448 385.73477173 41.1100502 13.8764801
		 385.73477173 10.16943359 0.240448 385.73477173 10.16943359 13.8764801 235.73474121 100 13.8764801
		 235.73474121 100 0.240448 235.73474121 41.1100502 0.240448 235.73474121 33.34619522 0.240448
		 235.73474121 10.16943359 0.240448 235.73474121 0 0.240448 235.73474121 0 13.8764801
		 235.73474121 10.16943359 13.8764801 235.73474121 33.34619522 13.8764801 235.73474121 41.1100502 13.8764801;
	setAttr -s 36 ".ed[0:35]"  0 1 0 1 9 0 2 3 0 3 6 0 4 8 0 4 13 1 5 7 0
		 5 4 1 6 4 0 6 12 1 7 2 0 7 6 1 8 0 0 8 14 1 9 5 0 9 8 1 10 2 0 11 3 0 10 11 0 11 12 0
		 12 13 0 13 14 0 15 0 0 14 15 0 16 1 0 15 16 0 17 9 1 16 17 0 18 5 1 17 18 0 19 7 1
		 18 19 0 19 10 0 12 19 0 13 18 0 14 17 0;
	setAttr -s 18 -ch 72 ".fc[0:17]" -type "polyFaces" 
		f 4 11 -4 -3 -11
		mu 0 4 28 1 12 19
		f 4 15 -5 -8 -15
		mu 0 4 35 7 13 18
		f 4 -9 -12 -7 7
		mu 0 4 20 1 28 30
		f 4 -13 -16 -2 -1
		mu 0 4 4 5 14 41
		f 4 16 2 -18 -19
		mu 0 4 2 3 10 11
		f 4 -20 17 3 9
		mu 0 4 43 44 45 46
		f 4 -21 -10 8 5
		mu 0 4 47 43 46 48
		f 4 -22 -6 4 13
		mu 0 4 49 47 48 50
		f 4 -24 -14 12 -23
		mu 0 4 51 52 53 54
		f 4 -26 22 0 -25
		mu 0 4 16 15 8 9
		f 4 -28 24 1 -27
		mu 0 4 39 40 17 42
		f 4 -30 26 14 -29
		mu 0 4 33 34 6 36
		f 4 -31 -32 28 6
		mu 0 4 0 25 26 21
		f 4 -17 -33 30 10
		mu 0 4 29 27 25 0
		f 4 19 33 32 18
		mu 0 4 23 22 25 27
		f 4 -34 20 34 31
		mu 0 4 25 22 24 26
		f 4 -35 21 35 29
		mu 0 4 33 32 31 34
		f 4 -36 23 25 27
		mu 0 4 39 38 37 40;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "Wall_Small_M";
	rename -uid "BF4962CD-4111-4E35-4B74-35848132B625";
	setAttr ".t" -type "double3" 0 0 -310.91501033617453 ;
	setAttr ".rp" -type "double3" 0 50.000007629394531 0 ;
	setAttr ".sp" -type "double3" 0 50.000007629394531 0 ;
createNode mesh -n "Wall_Small_MShape" -p "Wall_Small_M";
	rename -uid "DB854AF5-4053-484A-0ACA-CAB6DF71CF5C";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.73127126693725586 0.49867277260636911 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 30 ".uvst[0].uvsp[0:29]" -type "float2" 0.9414196 7.6987664e-05
		 0.94135827 0.38858584 0.88857597 0.3885859 0.88857567 7.6987664e-05 0.50006688 7.7345292e-05
		 0.50006717 0.38858613 0.44728494 0.38858619 0.44722271 7.7345292e-05 0.11155856 0.38858637
		 0.1115576 7.7583711e-05 0.83363259 0.61112404 0.83363259 0.99732184 0.49990308 0.99732184
		 0.49996448 0.61112404 0.55832517 0.55825967 0.55819434 0.55804533 0.44223416 0.44174004
		 0.55832517 0.44174004 1.29617524 0.44195431 1.29617524 0.55804533 -0.29617494 0.55825967
		 -0.29617494 0.44174004 0.058581412 0.38858643 0.05858022 7.770292e-05 0.55304444
		 0.38858607 0.55304414 7.7345292e-05 0.1664288 0.61107099 0.16636729 0.99726856 0.55819434
		 0.44195431 0.44223416 0.55825967;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcol" yes;
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 16 ".pt[0:15]" -type "float3"  -350.12915 7.6293945e-06 
		150.05617 -450.12909 7.6293945e-06 50.056183 -336.4931 7.6293945e-06 163.69218 -436.4931 
		7.6293945e-06 63.692169 -336.4931 7.6293945e-06 163.69218 -436.4931 7.6293945e-06 
		63.692169 -350.12915 7.6293945e-06 150.05617 -450.12909 7.6293945e-06 50.056183 -363.71503 
		7.6293945e-06 136.47032 -363.7309 7.6293945e-06 136.45442 -350.09485 7.6293945e-06 
		150.09044 -350.07892 7.6293945e-06 150.10634 -250.12915 7.6293945e-06 250.05615 -263.71503 
		7.6293945e-06 236.47031 -250.12915 7.6293945e-06 250.05615 -263.73096 7.6293945e-06 
		236.45441;
	setAttr -s 16 ".vt[0:15]"  400.12911987 0 -200.056167603 400.12911987 0 -100.056167603
		 386.49310303 0 -200.056167603 386.49310303 0 -100.056167603 386.49310303 100 -200.056167603
		 386.49310303 100 -100.056167603 400.12911987 100 -200.056167603 400.12911987 100 -100.056167603
		 400.12911987 100 -186.47032166 400.12911987 0 -186.454422 386.49310303 0 -186.454422
		 386.49310303 100 -186.47032166 300.12911987 100 -200.056152344 300.12911987 100 -186.4703064
		 300.12911987 0 -200.056152344 300.12911987 0 -186.45440674;
	setAttr -s 26 ".ed[0:25]"  0 9 0 4 11 0 6 8 0 0 2 0 1 3 0 2 4 0 4 6 0
		 5 7 0 7 1 0 6 0 0 3 5 0 8 7 0 9 1 0 8 9 1 10 3 0 11 5 0 10 11 0 11 8 1 4 12 0 11 13 0
		 12 13 0 14 12 0 15 13 0 2 14 0 10 15 0 14 15 0;
	setAttr -s 11 -ch 44 ".fc[0:10]" -type "polyFaces" 
		f 4 -26 21 20 -23
		mu 0 4 0 3 2 1
		f 4 6 2 -18 -2
		mu 0 4 14 17 16 29
		f 4 0 -14 -3 9
		mu 0 4 4 7 6 5
		f 4 4 10 7 8
		mu 0 4 9 23 22 8
		f 4 -6 -4 -10 -7
		mu 0 4 24 25 4 5
		f 4 13 12 -9 -12
		mu 0 4 6 7 9 8
		f 4 -15 16 15 -11
		mu 0 4 10 13 12 11
		f 4 11 -8 -16 17
		mu 0 4 16 21 20 29
		f 4 19 -21 -19 1
		mu 0 4 15 19 18 28
		f 4 -24 5 18 -22
		mu 0 4 3 25 24 2
		f 4 22 -20 -17 24
		mu 0 4 26 27 12 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode mesh -n "polySurfaceShape1" -p "Wall_Small_M";
	rename -uid "A6577E7F-47B2-9083-38FE-26949FB90C37";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.75 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 38 ".uvst[0].uvsp[0:37]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.625 0.91666663 0.70833331 0 0.29166666 0 0.375 0.91666663
		 0.29166666 0.25 0.375 0.33333334 0.625 0.33333334 0.70833331 0.25 0.625 0.89666229
		 0.72833765 0 0.27166235 0 0.375 0.89666229 0.27166235 0.25 0.375 0.35333765 0.625
		 0.35333765 0.72833765 0.25 0.625 0.97638381 0.64861619 0 0.35138381 0 0.375 0.97638381
		 0.35138381 0.25 0.375 0.27361619 0.625 0.27361619 0.64861619 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 14 ".pt";
	setAttr ".pt[0]" -type "float3" 0 -0.91252518 0 ;
	setAttr ".pt[1]" -type "float3" -284.19867 -0.91252518 -2.8312206e-07 ;
	setAttr ".pt[2]" -type "float3" 0 -0.91252518 0 ;
	setAttr ".pt[3]" -type "float3" -284.19867 -0.91252518 -2.8312206e-07 ;
	setAttr ".pt[4]" -type "float3" 0 1.789978 0 ;
	setAttr ".pt[5]" -type "float3" -284.19867 1.789978 -2.8312206e-07 ;
	setAttr ".pt[6]" -type "float3" 0 1.789978 0 ;
	setAttr ".pt[7]" -type "float3" -284.19867 1.789978 -2.8312206e-07 ;
	setAttr ".pt[8]" -type "float3" -284.19867 0 -2.8312206e-07 ;
	setAttr ".pt[11]" -type "float3" -284.19867 0 -2.8312206e-07 ;
	setAttr ".pt[12]" -type "float3" -284.19867 0 -2.8312206e-07 ;
	setAttr ".pt[15]" -type "float3" -284.19867 0 -2.8312206e-07 ;
	setAttr ".pt[16]" -type "float3" -284.19867 0 -2.8312206e-07 ;
	setAttr ".pt[19]" -type "float3" -284.19867 0 -2.8312206e-07 ;
	setAttr -s 20 ".vt[0:19]"  -7.22045994 -43.74690247 -7.65418911 459.27346802 -43.74690247 -7.65418911
		 -7.22045994 -43.74690247 2.73163319 459.27346802 -43.74690247 2.73163319 -7.22045994 44.45968628 2.73163319
		 459.060150146 44.45968628 2.73163319 -7.22045994 44.45968628 -7.65418911 459.060150146 44.45968628 -7.65418911
		 459.20233154 -14.34470272 -7.65418911 -7.22045994 -14.34470272 -7.65418911 -7.22045994 -14.34470272 2.73163319
		 459.20233154 -14.34470272 2.73163319 459.18527222 -7.28665495 -7.65418911 -7.22045994 -7.28665495 -7.65418911
		 -7.22045994 -7.28665495 2.73163319 459.18527222 -7.28665495 2.73163319 459.25332642 -35.41448593 -7.65418911
		 -7.22045994 -35.41448593 -7.65418911 -7.22045994 -35.41448593 2.73163319 459.25332642 -35.41448593 2.73163319;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 18 0
		 3 19 0 4 6 0 5 7 0 7 12 0 8 16 0 9 17 0 8 9 1 10 14 0 9 10 1 11 15 0 10 11 1 11 8 1
		 6 13 0 12 8 0 13 9 0 12 13 1 14 4 0 13 14 1 15 5 0 14 15 1 15 12 1 16 1 0 17 0 0
		 16 17 1 18 10 0 17 18 1 19 11 0 18 19 1 19 16 1;
	setAttr -s 18 -ch 72 ".fc[0:17]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 -3 -24 26 25
		mu 0 4 5 4 27 28
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 10 22 -20
		mu 0 4 6 7 22 25
		f 4 27 -11 -10 -26
		mu 0 4 29 23 10 11
		f 4 8 19 24 23
		mu 0 4 13 12 24 26
		f 4 -14 11 30 -13
		mu 0 4 17 14 30 33
		f 4 -16 12 32 31
		mu 0 4 18 16 32 34
		f 4 34 33 -18 -32
		mu 0 4 35 36 20 19
		f 4 35 -12 -19 -34
		mu 0 4 37 31 15 21
		f 4 -23 20 13 -22
		mu 0 4 25 22 14 17
		f 4 -25 21 15 14
		mu 0 4 26 24 16 18
		f 4 -27 -15 17 16
		mu 0 4 28 27 19 20
		f 4 -21 -28 -17 18
		mu 0 4 15 23 29 21
		f 4 -31 28 -1 -30
		mu 0 4 33 30 9 8
		f 4 -33 29 4 6
		mu 0 4 34 32 0 2
		f 4 1 7 -35 -7
		mu 0 4 2 3 36 35
		f 4 -29 -36 -8 -6
		mu 0 4 1 31 37 3;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode mesh -n "polySurfaceShape10" -p "Wall_Small_M";
	rename -uid "488A04ED-4356-C59E-CDBB-30BE547D1AB0";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.44830673933029175 0.74702408909797668 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 81 ".uvst[0].uvsp[0:80]" -type "float2" 0.38391656 0.61904585
		 0.38386422 0.62117922 0.38172561 0.62112665 0.38177788 0.61899358 0.26125172 0.92460072
		 0.26122311 0.92299753 0.5893212 0.65469635 0.5848043 0.65485895 0.26283213 0.92296886
		 0.26286077 0.92457199 0.26104105 0.91280067 0.26265007 0.91277194 0.58409637 0.63527977
		 0.58861643 0.63511705 0.59385478 0.65453321 0.59314996 0.63495386 0.25106075 0.92478263
		 0.25103211 0.92317951 0.27648351 0.86762667 0.58852351 0.63253582 0.58400303 0.63269854
		 0.58372438 0.62499297 0.58824611 0.62483019 0.59305704 0.63237262 0.5927797 0.62466699
		 0.24629077 0.92638826 0.24916956 0.92758346 0.24944839 0.92532742 0.55607396 0.65589315
		 0.55536914 0.63631386 0.36801985 0.61293781 0.55527622 0.63373262 0.55499882 0.62602699
		 0.36823297 0.6186614 0.36818063 0.62079459 0.38353199 0.63472939 0.38139331 0.63467693
		 0.36873552 0.61293811 0.6313377 0.37920666 0.24657944 0.92412543 0.27475333 0.86762744
		 0.62186366 0.63392025 0.62256843 0.65349954 0.27474982 0.86012793 0.62149334 0.62363338
		 0.62177068 0.63133901 0.24832603 0.92517883 0.36801961 0.61347306 0.27648115 0.86012709
		 0.29848307 0.86011857 0.3002196 0.86011779 0.30022311 0.86761731 0.37327963 0.61294079
		 0.3732793 0.61347586 0.29848653 0.86761814 0.27474937 0.8591392 0.27648085 0.85913843
		 0.30021912 0.85912901 0.2984826 0.85912985 0.28747955 0.86012375 0.28747925 0.85913497
		 0.28748184 0.86762333 0.26167333 0.91724712 0.26192307 0.91493344 0.26707077 0.93271089
		 0.26685292 0.93492466 0.3778255 0.61294258 0.24860977 0.92290914 0.63135469 0.37783203
		 0.63216108 0.37784189 0.62109095 0.37908062 0.62028223 0.37907076 0.62029898 0.37769613
		 0.62110776 0.37770605 0.62623239 0.37776861 0.6262154 0.37914321 0.63214433 0.37921649
		 0.37782529 0.61347777 0.36873519 0.61347324 0.37854275 0.61347806 0.37854299 0.61294293;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcol" yes;
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 40 ".vt[0:39]"  400.12911987 0 -200.056167603 400.12911987 0 -100.056167603
		 386.49310303 0 -200.056167603 386.49310303 0 -100.056167603 386.49310303 100 -200.056167603
		 386.49310303 100 -100.056167603 400.12911987 100 -200.056167603 400.12911987 100 -100.056167603
		 400.12911987 33.34619904 -100.056167603 400.12911987 33.34619904 -200.056167603 386.49310303 33.34619904 -200.056167603
		 386.49310303 33.34619904 -100.056167603 400.12911987 41.1100502 -100.056167603 400.12911987 41.1100502 -200.056167603
		 386.49310303 41.1100502 -200.056167603 386.49310303 41.1100502 -100.056167603 400.12911987 10.16942978 -100.056167603
		 400.12911987 10.16942978 -200.056167603 386.49310303 10.16942978 -200.056167603 386.49310303 10.16942978 -100.056167603
		 400.12911987 100 -186.47032166 400.12911987 41.1100502 -186.46098328 400.12911987 33.34619904 -186.45973206
		 400.12911987 10.16942978 -186.45591736 400.12911987 0 -186.454422 386.49310303 0 -186.454422
		 386.49310303 10.16942978 -186.45591736 386.49310303 33.34619141 -186.45973206 386.49310303 41.1100502 -186.46098328
		 386.49310303 100 -186.47032166 300.12911987 100 -200.056152344 300.12911987 100 -186.4703064
		 300.12911987 41.1100502 -200.056152344 300.12911987 41.1100502 -186.46096802 300.12911987 10.16942978 -200.056152344
		 300.12911987 10.16942978 -186.4559021 300.12911987 33.34619141 -186.4597168 300.12911987 33.34619904 -200.056152344
		 300.12911987 0 -200.056152344 300.12911987 0 -186.45440674;
	setAttr -s 76 ".ed[0:75]"  0 24 0 2 25 0 4 29 0 6 20 0 0 2 0 1 3 0 2 18 0
		 3 19 0 4 6 0 5 7 0 7 12 0 8 16 0 9 17 0 8 22 1 10 14 0 9 10 1 11 15 0 11 8 1 6 13 0
		 12 8 0 13 9 0 12 21 1 14 4 0 13 14 1 15 5 0 15 12 1 16 1 0 17 0 0 16 23 1 18 10 0
		 17 18 1 19 11 0 19 16 1 20 7 0 21 13 1 20 21 1 22 9 1 21 22 1 23 17 1 22 23 1 24 1 0
		 23 24 1 25 3 0 24 25 1 26 19 1 25 26 0 27 11 1 26 27 0 28 15 1 27 28 0 29 5 0 28 29 0
		 29 20 1 4 30 0 29 31 0 30 31 0 14 32 0 32 30 0 28 33 0 32 33 1 33 31 0 18 34 0 26 35 0
		 34 35 1 27 36 0 35 36 0 10 37 0 37 36 1 34 37 0 37 32 0 36 33 0 2 38 0 25 39 0 38 39 0
		 39 35 0 38 34 0;
	setAttr -s 38 -ch 152 ".fc[0:37]" -type "polyFaces" 
		f 4 0 43 -2 -5
		mu 0 4 0 1 2 3
		f 4 -56 -58 59 60
		mu 0 4 18 40 43 48
		f 4 2 52 -4 -9
		mu 0 4 4 5 8 9
		f 4 3 35 34 -19
		mu 0 4 6 7 12 13
		f 4 25 -11 -10 -25
		mu 0 4 49 50 51 54
		f 4 8 18 23 22
		mu 0 4 14 6 13 15
		f 4 -37 39 38 -13
		mu 0 4 19 20 21 22
		f 4 -16 12 30 29
		mu 0 4 23 19 22 24
		f 4 63 65 -68 -69
		mu 0 4 76 38 68 69
		f 4 32 -12 -18 -32
		mu 0 4 70 71 72 73
		f 4 -35 37 36 -21
		mu 0 4 13 12 20 19
		f 4 -24 20 15 14
		mu 0 4 15 13 19 23
		f 4 -60 -70 67 70
		mu 0 4 48 43 55 56
		f 4 -20 -26 -17 17
		mu 0 4 57 50 49 58
		f 4 -39 41 -1 -28
		mu 0 4 25 26 27 39
		f 4 -31 27 4 6
		mu 0 4 46 25 39 67
		f 4 73 74 -64 -76
		mu 0 4 30 37 78 47
		f 4 -27 -33 -8 -6
		mu 0 4 80 79 77 66
		f 4 33 10 21 -36
		mu 0 4 7 28 29 12
		f 4 -38 -22 19 13
		mu 0 4 20 12 29 31
		f 4 -40 -14 11 28
		mu 0 4 21 20 31 32
		f 4 -42 -29 26 -41
		mu 0 4 27 26 65 64
		f 4 -44 40 5 -43
		mu 0 4 2 1 35 36
		f 4 -46 42 7 -45
		mu 0 4 53 52 66 77
		f 4 -48 44 31 -47
		mu 0 4 74 75 70 73
		f 4 -49 -50 46 16
		mu 0 4 49 59 60 58
		f 4 -51 -52 48 24
		mu 0 4 54 61 59 49
		f 4 -53 50 9 -34
		mu 0 4 8 5 10 11
		f 4 -3 53 55 -55
		mu 0 4 5 4 16 17
		f 4 -23 56 57 -54
		mu 0 4 14 15 41 42
		f 4 51 54 -61 -59
		mu 0 4 59 61 18 48
		f 4 47 64 -66 -63
		mu 0 4 75 74 68 38
		f 4 -30 61 68 -67
		mu 0 4 23 24 44 45
		f 4 -15 66 69 -57
		mu 0 4 15 23 45 41
		f 4 49 58 -71 -65
		mu 0 4 60 59 48 56
		f 4 1 72 -74 -72
		mu 0 4 3 2 34 33
		f 4 45 62 -75 -73
		mu 0 4 52 53 78 37
		f 4 -7 71 75 -62
		mu 0 4 46 67 63 62;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "205EB3E2-4E64-9D4A-31C8-AA87C0138FE9";
	setAttr -s 9 ".lnk";
	setAttr -s 9 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "7CE87820-47CD-904E-D4F2-43AC3DBF3773";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "DA74AC4E-47E4-8B8F-E6DE-CCB616F1BF98";
createNode displayLayerManager -n "layerManager";
	rename -uid "A2021810-4B1E-F0B1-2FFF-4C9D4F6EDE39";
	setAttr -s 2 ".dli[1]"  5;
	setAttr -s 2 ".dli";
createNode displayLayer -n "defaultLayer";
	rename -uid "6A9BDD1B-4C3B-7780-99CA-2BA5E95C5B22";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "73FB6A1D-48C9-BABF-506F-D99D2A4FA020";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "BB30D240-4758-7D11-92FE-0384C490943B";
	setAttr ".g" yes;
createNode displayLayer -n "oop:layer1";
	rename -uid "EC44141D-4BE5-F1FC-1CAF-9CBAF2D4AD2B";
	setAttr ".do" 1;
createNode materialInfo -n "pasted__materialInfo7";
	rename -uid "1CED099A-468D-DF48-EDD9-9B82A701BAA3";
createNode shadingEngine -n "pasted__lambert9SG";
	rename -uid "4A151A09-490F-07D0-CF3D-03BE8C155785";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode lambert -n "pasted__Buldding";
	rename -uid "B0BE4A0C-460D-0372-64CA-5E87F28D1A23";
createNode file -n "pasted__file7";
	rename -uid "E4E9B521-45A3-9565-5E92-AE90A2302265";
	setAttr ".ftn" -type "string" "D:/Chandrakant/Futuristic_School/Texture/Colour_Pallet.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "pasted__place2dTexture5";
	rename -uid "3514F4DB-4B9B-5380-08F8-A1ABC4DC7C3C";
createNode script -n "uiConfigurationScriptNode";
	rename -uid "C3E0DD0F-4389-8FFF-5533-128A2957C6B4";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $nodeEditorPanelVisible = stringArrayContains(\"nodeEditorPanel1\", `getPanel -vis`);\n\tint    $nodeEditorWorkspaceControlOpen = (`workspaceControl -exists nodeEditorPanel1Window` && `workspaceControl -q -visible nodeEditorPanel1Window`);\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\n\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 1\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 1\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 547\n            -height 352\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 1\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 1\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n"
		+ "            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n"
		+ "            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 546\n            -height 352\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 547\n            -height 352\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n"
		+ "            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 1\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n"
		+ "            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n"
		+ "            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1100\n            -height 748\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -docTag \"isolOutln_fromSeln\" \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n"
		+ "            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -selectCommand \"print(\\\"\\\")\" \n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n"
		+ "            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n"
		+ "            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n"
		+ "            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n"
		+ "                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n"
		+ "                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -autoFitTime 0\n"
		+ "                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -showCurveNames 0\n                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                -valueLinesToggle 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n"
		+ "                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n"
		+ "                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n"
		+ "                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif ($nodeEditorPanelVisible || $nodeEditorWorkspaceControlOpen) {\n"
		+ "\t\tif (\"\" == $panelName) {\n\t\t\tif ($useSceneConfig) {\n\t\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n"
		+ "                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -editorMode \"default\" \n                $editorName;\n\t\t\t}\n\t\t} else {\n\t\t\t$label = `panel -q -label $panelName`;\n\t\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n"
		+ "                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -editorMode \"default\" \n                $editorName;\n\t\t\tif (!$useSceneConfig) {\n\t\t\t\tpanel -e -l $label $panelName;\n\t\t\t}\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"Stereo\" (localizedPanelLabel(\"Stereo\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels  $panelName;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n"
		+ "                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n"
		+ "                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -controllers 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n"
		+ "                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 0\n                -height 0\n                -sceneRenderFilter 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n            stereoCameraView -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n"
		+ "\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1100\\n    -height 748\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1100\\n    -height 748\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 50 -size 1000 -divisions 1 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "7E378CF9-4391-74AB-FB4B-A4875C91BDA2";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
createNode lambert -n "Color_Pallet_Mat";
	rename -uid "6D16131E-4AE1-AE44-EF98-B78061D523CF";
createNode shadingEngine -n "lambert2SG";
	rename -uid "AED4BF49-4B2C-F2CE-A9EE-9894B617745E";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo1";
	rename -uid "AE1D344E-4A31-785E-BE6A-5DAD1BEC19C1";
createNode file -n "file1";
	rename -uid "11FCEFB6-4B7C-94E5-C5E6-DF99BDC89900";
	setAttr ".ftn" -type "string" "D:/Color_Pallet.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture1";
	rename -uid "2A6ACE14-499F-8FDB-EF9A-AE89534E5B7C";
createNode lambert -n "Floor_Mat_01";
	rename -uid "23B09054-4454-C823-200E-3490FBF41E6B";
createNode shadingEngine -n "lambert3SG";
	rename -uid "A4D1D91A-4B9D-ECBA-1272-A99766399BD0";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo2";
	rename -uid "59AC3D0C-40DB-9736-C99E-B1B5E2B70112";
createNode file -n "file2";
	rename -uid "9E08C2C9-4B4F-60A7-A3B7-A8BBDFDECCF8";
	setAttr ".ftn" -type "string" "D:/Ved/3D Work Games and fbx/Idle_Baby_Spa/Exports/Fbx/Wall_Floor_M/Wall_Floor_M/Texture/Floor_T_01.jpg";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture2";
	rename -uid "35A88EF4-4BF7-26E8-967D-E1882C99D19F";
	setAttr ".re" -type "float2" 5 5 ;
createNode lambert -n "lambert4";
	rename -uid "7D630A72-4D89-8ED0-9D15-0E838AB13809";
createNode shadingEngine -n "lambert4SG";
	rename -uid "89F40742-4977-7AFD-056E-B793B885921B";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo3";
	rename -uid "742DA724-4C90-AC48-92A8-BB8029B1D5BA";
createNode lambert -n "Inside_Outside_Wall_Mat";
	rename -uid "C7A6FBF0-4E56-EC19-8830-77BCD9A20EBC";
createNode shadingEngine -n "lambert5SG";
	rename -uid "FCE9B208-4973-3616-84F9-959C86C42B41";
	setAttr ".ihi" 0;
	setAttr -s 3 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 2 ".gn";
createNode materialInfo -n "materialInfo4";
	rename -uid "6D5E07F0-447C-AE9D-9AC4-8FAA868B56EA";
createNode file -n "file3";
	rename -uid "193B31F2-4562-A5F4-3649-D6B25C9B0397";
	setAttr ".ftn" -type "string" "D:/Ved/3D Work Games and fbx/Idle_Baby_Spa/Photoshop_PSD/Inside_Outside_Wall_Texture.psd";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture3";
	rename -uid "8230F183-42D0-8ABE-C3DB-1A8E25A6F6AF";
createNode lambert -n "White";
	rename -uid "185491A4-48B5-FAE4-F809-79BCB398196D";
	setAttr ".c" -type "float3" 0.88961041 0.88961041 0.88961041 ;
createNode shadingEngine -n "lambert6SG";
	rename -uid "B39988FF-464C-28CF-4FD7-0E87341B6E7D";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo5";
	rename -uid "A17C98AF-4956-4378-54AF-3C9188BC87E2";
createNode lambert -n "Inide_Wall__Mat";
	rename -uid "7B7E2E1D-41B4-7EE2-6095-F4BEBE922479";
createNode shadingEngine -n "lambert7SG";
	rename -uid "CEA5DC4E-42BE-663C-7414-7082BC0898ED";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo6";
	rename -uid "220C0FCB-4644-74A0-952E-ACA510D72C30";
createNode file -n "file4";
	rename -uid "4684B6D1-4CE2-BF77-56A9-E3B321256C32";
	setAttr ".ftn" -type "string" "D:/Ved/3D Work Games and fbx/Idle_Baby_Spa/Photoshop_PSD/Inide_Wall_Texture.psd";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture4";
	rename -uid "599E837F-41E4-3A0C-1F6D-40A618EDCA3A";
createNode groupId -n "groupId1";
	rename -uid "64511448-45B9-28EA-4F3E-E7AE77515638";
	setAttr ".ihi" 0;
createNode groupId -n "groupId2";
	rename -uid "E1E24314-495B-C1DE-C48B-7F819BB36DBA";
	setAttr ".ihi" 0;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".msaa" yes;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 9 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 11 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 5 ".u";
select -ne :defaultRenderingList1;
select -ne :defaultTextureList1;
	setAttr -s 5 ".tx";
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "groupId1.id" "Wall_Big_MShape.iog.og[1].gid";
connectAttr "lambert5SG.mwc" "Wall_Big_MShape.iog.og[1].gco";
connectAttr "groupId2.id" "Wall_Big_MShape.iog.og[2].gid";
connectAttr "lambert5SG.mwc" "Wall_Big_MShape.iog.og[2].gco";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "pasted__lambert9SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert2SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert3SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert4SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert5SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert6SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert7SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "pasted__lambert9SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert2SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert3SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert4SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert5SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert6SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert7SG.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "layerManager.dli[1]" "oop:layer1.id";
connectAttr "pasted__lambert9SG.msg" "pasted__materialInfo7.sg";
connectAttr "pasted__Buldding.msg" "pasted__materialInfo7.m";
connectAttr "pasted__file7.msg" "pasted__materialInfo7.t" -na;
connectAttr "pasted__Buldding.oc" "pasted__lambert9SG.ss";
connectAttr "pasted__file7.oc" "pasted__Buldding.c";
connectAttr ":defaultColorMgtGlobals.cme" "pasted__file7.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "pasted__file7.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "pasted__file7.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "pasted__file7.ws";
connectAttr "pasted__place2dTexture5.c" "pasted__file7.c";
connectAttr "pasted__place2dTexture5.tf" "pasted__file7.tf";
connectAttr "pasted__place2dTexture5.rf" "pasted__file7.rf";
connectAttr "pasted__place2dTexture5.mu" "pasted__file7.mu";
connectAttr "pasted__place2dTexture5.mv" "pasted__file7.mv";
connectAttr "pasted__place2dTexture5.s" "pasted__file7.s";
connectAttr "pasted__place2dTexture5.wu" "pasted__file7.wu";
connectAttr "pasted__place2dTexture5.wv" "pasted__file7.wv";
connectAttr "pasted__place2dTexture5.re" "pasted__file7.re";
connectAttr "pasted__place2dTexture5.of" "pasted__file7.of";
connectAttr "pasted__place2dTexture5.r" "pasted__file7.ro";
connectAttr "pasted__place2dTexture5.n" "pasted__file7.n";
connectAttr "pasted__place2dTexture5.vt1" "pasted__file7.vt1";
connectAttr "pasted__place2dTexture5.vt2" "pasted__file7.vt2";
connectAttr "pasted__place2dTexture5.vt3" "pasted__file7.vt3";
connectAttr "pasted__place2dTexture5.vc1" "pasted__file7.vc1";
connectAttr "pasted__place2dTexture5.o" "pasted__file7.uv";
connectAttr "pasted__place2dTexture5.ofs" "pasted__file7.fs";
connectAttr "file1.oc" "Color_Pallet_Mat.c";
connectAttr "Color_Pallet_Mat.oc" "lambert2SG.ss";
connectAttr "Gate_MShape.iog" "lambert2SG.dsm" -na;
connectAttr "lambert2SG.msg" "materialInfo1.sg";
connectAttr "Color_Pallet_Mat.msg" "materialInfo1.m";
connectAttr "file1.msg" "materialInfo1.t" -na;
connectAttr ":defaultColorMgtGlobals.cme" "file1.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file1.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file1.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file1.ws";
connectAttr "place2dTexture1.c" "file1.c";
connectAttr "place2dTexture1.tf" "file1.tf";
connectAttr "place2dTexture1.rf" "file1.rf";
connectAttr "place2dTexture1.mu" "file1.mu";
connectAttr "place2dTexture1.mv" "file1.mv";
connectAttr "place2dTexture1.s" "file1.s";
connectAttr "place2dTexture1.wu" "file1.wu";
connectAttr "place2dTexture1.wv" "file1.wv";
connectAttr "place2dTexture1.re" "file1.re";
connectAttr "place2dTexture1.of" "file1.of";
connectAttr "place2dTexture1.r" "file1.ro";
connectAttr "place2dTexture1.n" "file1.n";
connectAttr "place2dTexture1.vt1" "file1.vt1";
connectAttr "place2dTexture1.vt2" "file1.vt2";
connectAttr "place2dTexture1.vt3" "file1.vt3";
connectAttr "place2dTexture1.vc1" "file1.vc1";
connectAttr "place2dTexture1.o" "file1.uv";
connectAttr "place2dTexture1.ofs" "file1.fs";
connectAttr "file2.oc" "Floor_Mat_01.c";
connectAttr "Floor_Mat_01.oc" "lambert3SG.ss";
connectAttr "Floor_MShape.iog" "lambert3SG.dsm" -na;
connectAttr "lambert3SG.msg" "materialInfo2.sg";
connectAttr "Floor_Mat_01.msg" "materialInfo2.m";
connectAttr "file2.msg" "materialInfo2.t" -na;
connectAttr ":defaultColorMgtGlobals.cme" "file2.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file2.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file2.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file2.ws";
connectAttr "place2dTexture2.c" "file2.c";
connectAttr "place2dTexture2.tf" "file2.tf";
connectAttr "place2dTexture2.rf" "file2.rf";
connectAttr "place2dTexture2.mu" "file2.mu";
connectAttr "place2dTexture2.mv" "file2.mv";
connectAttr "place2dTexture2.s" "file2.s";
connectAttr "place2dTexture2.wu" "file2.wu";
connectAttr "place2dTexture2.wv" "file2.wv";
connectAttr "place2dTexture2.re" "file2.re";
connectAttr "place2dTexture2.of" "file2.of";
connectAttr "place2dTexture2.r" "file2.ro";
connectAttr "place2dTexture2.n" "file2.n";
connectAttr "place2dTexture2.vt1" "file2.vt1";
connectAttr "place2dTexture2.vt2" "file2.vt2";
connectAttr "place2dTexture2.vt3" "file2.vt3";
connectAttr "place2dTexture2.vc1" "file2.vc1";
connectAttr "place2dTexture2.o" "file2.uv";
connectAttr "place2dTexture2.ofs" "file2.fs";
connectAttr "lambert4.oc" "lambert4SG.ss";
connectAttr "lambert4SG.msg" "materialInfo3.sg";
connectAttr "lambert4.msg" "materialInfo3.m";
connectAttr "file3.oc" "Inside_Outside_Wall_Mat.c";
connectAttr "Inside_Outside_Wall_Mat.oc" "lambert5SG.ss";
connectAttr "Wall_Small_MShape.iog" "lambert5SG.dsm" -na;
connectAttr "Wall_Big_MShape.iog.og[1]" "lambert5SG.dsm" -na;
connectAttr "Wall_Big_MShape.iog.og[2]" "lambert5SG.dsm" -na;
connectAttr "groupId1.msg" "lambert5SG.gn" -na;
connectAttr "groupId2.msg" "lambert5SG.gn" -na;
connectAttr "lambert5SG.msg" "materialInfo4.sg";
connectAttr "Inside_Outside_Wall_Mat.msg" "materialInfo4.m";
connectAttr "file3.msg" "materialInfo4.t" -na;
connectAttr ":defaultColorMgtGlobals.cme" "file3.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file3.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file3.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file3.ws";
connectAttr "place2dTexture3.c" "file3.c";
connectAttr "place2dTexture3.tf" "file3.tf";
connectAttr "place2dTexture3.rf" "file3.rf";
connectAttr "place2dTexture3.mu" "file3.mu";
connectAttr "place2dTexture3.mv" "file3.mv";
connectAttr "place2dTexture3.s" "file3.s";
connectAttr "place2dTexture3.wu" "file3.wu";
connectAttr "place2dTexture3.wv" "file3.wv";
connectAttr "place2dTexture3.re" "file3.re";
connectAttr "place2dTexture3.of" "file3.of";
connectAttr "place2dTexture3.r" "file3.ro";
connectAttr "place2dTexture3.n" "file3.n";
connectAttr "place2dTexture3.vt1" "file3.vt1";
connectAttr "place2dTexture3.vt2" "file3.vt2";
connectAttr "place2dTexture3.vt3" "file3.vt3";
connectAttr "place2dTexture3.vc1" "file3.vc1";
connectAttr "place2dTexture3.o" "file3.uv";
connectAttr "place2dTexture3.ofs" "file3.fs";
connectAttr "White.oc" "lambert6SG.ss";
connectAttr "lambert6SG.msg" "materialInfo5.sg";
connectAttr "White.msg" "materialInfo5.m";
connectAttr "file4.oc" "Inide_Wall__Mat.c";
connectAttr "Inide_Wall__Mat.oc" "lambert7SG.ss";
connectAttr "Inide_WallShape.iog" "lambert7SG.dsm" -na;
connectAttr "lambert7SG.msg" "materialInfo6.sg";
connectAttr "Inide_Wall__Mat.msg" "materialInfo6.m";
connectAttr "file4.msg" "materialInfo6.t" -na;
connectAttr ":defaultColorMgtGlobals.cme" "file4.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file4.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file4.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file4.ws";
connectAttr "place2dTexture4.c" "file4.c";
connectAttr "place2dTexture4.tf" "file4.tf";
connectAttr "place2dTexture4.rf" "file4.rf";
connectAttr "place2dTexture4.mu" "file4.mu";
connectAttr "place2dTexture4.mv" "file4.mv";
connectAttr "place2dTexture4.s" "file4.s";
connectAttr "place2dTexture4.wu" "file4.wu";
connectAttr "place2dTexture4.wv" "file4.wv";
connectAttr "place2dTexture4.re" "file4.re";
connectAttr "place2dTexture4.of" "file4.of";
connectAttr "place2dTexture4.r" "file4.ro";
connectAttr "place2dTexture4.n" "file4.n";
connectAttr "place2dTexture4.vt1" "file4.vt1";
connectAttr "place2dTexture4.vt2" "file4.vt2";
connectAttr "place2dTexture4.vt3" "file4.vt3";
connectAttr "place2dTexture4.vc1" "file4.vc1";
connectAttr "place2dTexture4.o" "file4.uv";
connectAttr "place2dTexture4.ofs" "file4.fs";
connectAttr "pasted__lambert9SG.pa" ":renderPartition.st" -na;
connectAttr "lambert2SG.pa" ":renderPartition.st" -na;
connectAttr "lambert3SG.pa" ":renderPartition.st" -na;
connectAttr "lambert4SG.pa" ":renderPartition.st" -na;
connectAttr "lambert5SG.pa" ":renderPartition.st" -na;
connectAttr "lambert6SG.pa" ":renderPartition.st" -na;
connectAttr "lambert7SG.pa" ":renderPartition.st" -na;
connectAttr "pasted__Buldding.msg" ":defaultShaderList1.s" -na;
connectAttr "Color_Pallet_Mat.msg" ":defaultShaderList1.s" -na;
connectAttr "Floor_Mat_01.msg" ":defaultShaderList1.s" -na;
connectAttr "lambert4.msg" ":defaultShaderList1.s" -na;
connectAttr "Inside_Outside_Wall_Mat.msg" ":defaultShaderList1.s" -na;
connectAttr "White.msg" ":defaultShaderList1.s" -na;
connectAttr "Inide_Wall__Mat.msg" ":defaultShaderList1.s" -na;
connectAttr "pasted__place2dTexture5.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture1.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture2.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture3.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture4.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "pasted__file7.msg" ":defaultTextureList1.tx" -na;
connectAttr "file1.msg" ":defaultTextureList1.tx" -na;
connectAttr "file2.msg" ":defaultTextureList1.tx" -na;
connectAttr "file3.msg" ":defaultTextureList1.tx" -na;
connectAttr "file4.msg" ":defaultTextureList1.tx" -na;
// End of Wall_Floor_M.ma
