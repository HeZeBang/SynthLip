   M S B A M L   `   `   `  ���� F  BSynthLipWPF, Version=0.1.1.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SynthLipWPFSynthLipWPF      SynthLipWPF.Mainfrm   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:SynthLipWPF     D @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   -     � Title$  SynthLipWPFDemo��$	��450��$	��800��0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle$
 True��.��� .+��� -    ��Name$ Climportbut��$��剪贴板导入��$��	10,10,0,0q�$	��Top=�$	��100���� -   $ Skimportbut��$��加载皮肤��$��
115,10,0,0q�$	��Top=�$	��100���� -   $ 	Phogenbut��$��生成音素��$��
220,10,0,0q�$	��Top=�$	��100���� -   $ 	Outputbut��$��导出序列��$��
325,10,0,0q�$	��Top=�$	��100���� -    ��Name$ tabcon��$��0,46,0,0q�.@��� $��Notes��.��� .+��� -    ��Name$ noteView��$��1,1,1,1q����	#33000000���	#33FFFFFF$��Stretch=� �� View �� .P��� $
��Note�� �� Width$	 120�� �� DisplayMemberBinding �� *
item.Lrc+�� $��Phoneme��$	 100�� �� *otp+�� $��Onset��$	 180�� �� *
item.Ons+�� $��Duration��$	 180�� �� *
item.Dur+�� $��Metas��.���  � ColumnDefinitions �� $	��27* ��� $
��773* �.+��� -   $ metaView��$��2��$��1,1,1,1q����	#33000000���	#33FFFFFF �� .P��� $��Phoneme��$	 100�� �� *	PhnName+�� $��Onset��$	 180�� �� *
PhnOnset+�� $��Duration��$	 180�� �� *PhnDuration+�� $��Source��$ 80�� �� *	PhnSource+�� $
��Type��$ 80�� �� *	PhnType+�� $��FilePath��$	 200�� �� *	PhnPath+�� $��About SynthLip��.��� 	 � RowDefinitions	 �� $
��167* ��� $
��183* � �� �� $	��262 �.+��� $��0��$
��Auto=�$
��Auto=�$��2��$��10,10,10,10q�$��1,1,1,1q����	#33000000���	#33FFFFFF.���� -	   
 ��Name$
 
aboutlabel��$��0��$��Label��$��10,10,10,10q��� -
   $ 
Refreshbut��$��1��$��刷新��$��
10,10,18,0q�$	��Top=�$��31��$��Stretch=��� -   $ 	Chkupdbut��$��1��$��检查更新��$��10,51,138,0q�$	��Top=�$��31��$��Stretch=��� -    ��Name$ 
UrlSrccomb��$��1��$��
129,50,0,0q�$	��115��$��31��.@���  �� 
IsSelected$
 True��.��	Gitee 源�� .��
GitHub 源� $��1��$��0,87,0,0q�$��2��.+��� $��0��$
��Auto=�$
��Auto=�$��2��$��1,1,1,1q�$y�Visible=����	#33000000���	#33FFFFFF$��10,10,10,10q�.���� -   $
 Updlabel��$�� ��$��1��$
��Left=�$	��Top=�$��2��$��2,2,2,2q�$��
10,10,10,0q�