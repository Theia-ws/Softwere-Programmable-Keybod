using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.KeyBordMaker {

	/// <summary>
	/// �L�[�{�[�h�ɕ\������L�[�g�b�v�̈ꗗ��ێ�����N���X
	/// </summary>
	[Serializable]
	class KeyMapList:ReadOnlyDictionary<string,KeyMap> {

		#region �v���p�e�B

		/// <summary>
		/// �L�[�}�b�v�̍������擾�܂��͐ݒ肵�܂��B
		/// </summary>
		internal int Height {
			get;
			private set;
		}

		/// <summary>
		/// �L�[�}�b�v�̕����擾�܂��͐ݒ肵�܂��B
		/// </summary>
		internal int Width {
			get;
			private set;
		}

		/// <summary>
		/// �L�[�}�b�v�̓o�^��ƂȂ�Grid �N���X�̃C���X�^���X���擾�܂��͐ݒ肵�܂��B
		/// </summary>
		private Grid PiarentGrid {
			get;
			set;
		}

		/// <summary>
		/// �f�t�H���g�̃L�[�}�b�v���擾�܂��͐ݒ肵�܂��B
		/// </summary>
		private KeyMap DefaultKeyMap {
			get;
			set;
		}

		/// <summary>
		/// ���ݕ\�����̃L�[�}�b�v���擾�܂��͐ݒ肵�܂��B
		/// </summary>
		private KeyMap NowMap {
			get;
			set;
		}

		/// <summary>
		/// �L�[�g�b�v�̍X�V�����X���b�h�̃L�����Z���g�[�N�����擾�܂��͐ݒ肵�܂��B
		/// </summary>
		private CancellationTokenSource KeyTopUpdateTokenSource {
			get;
			set;
		}

		/// <summary>
		/// �L�[�g�b�v�X�V�����X���b�h�̃C���X�^���X���擾�܂��͐ݒ肵�܂��B
		/// </summary>
		private Task KeyTopUpdateTask {
			get;
			set;
		}

		#endregion

		#region �L�[�}�b�v���X�g����

		/// <summary>
		/// �L�[�}�b�v���X�g���쐬���܂��B
		/// </summary>
		/// <param name="keyMapSet">�L�[�}�b�v�Z�b�g��`�̃C���X�^���X�B</param>
		/// <param name="piarent">�L�[�}�b�v�̓o�^��ƂȂ�Grid �N���X�̃C���X�^���X�B</param>
		/// <returns>�L�[�}�b�v���X�g�̃C���X�^���X</returns>
		internal static KeyMapList MakeKeyMapList(KeyMapSet keyMapSet,Grid piarent) {

			//�����`�F�b�N
			if(keyMapSet==null) {
				return null;
			}

			//�L�[�}�b�v�𐶐�
			var keyMapDictionary = new Dictionary<string,KeyMap>();
			KeyMap defaultKeyMap = null;
			for(var keyMapCounter = 0;keyMapCounter<keyMapSet.KeyMap.Count;keyMapCounter++) {
				var keyMap = new KeyMap(keyMapSet.KeyMap[keyMapCounter]);
				keyMapDictionary.Add(keyMapSet.KeyMap[keyMapCounter].Name,keyMap);
				if(keyMapSet.KeyMap[keyMapCounter].Default>0) {
					defaultKeyMap=keyMap;
				}
			}

			//�L�[�}�b�v���X�g�ɒl��ݒ�
			var keyMapList = new KeyMapList(keyMapDictionary) {
				DefaultKeyMap=defaultKeyMap,
				Height=keyMapSet.WindowHeight,
				PiarentGrid=piarent,
				Width=keyMapSet.WindowWidth
			};

			//�L�[�}�b�v�ύX�������L�[�ɐݒ�
			foreach(var keyMap in keyMapList) {
				foreach(var key in keyMap.Value.Keys) {
					key.SetAfterMap(keyMapList);
					key.KeyMapChangeProcess+=keyMapList.KeyMapChenge;
				}
			}

			return keyMapList;
		}

		/// <summary>
		/// KeyMapList �N���X�̐V�����C���X�^���X�����������܂��B
		/// </summary>
		/// <param name="source">KeyMapList �ɓo�^����KiyMap �N���X�̃C���X�^���X�̃\�[�X�B</param>
		private KeyMapList(IDictionary<string,KeyMap> source) : base(source) {
		}

		#endregion

		#region �L�[�}�b�v�̑J�ڏ���

		/// <summary>
		/// �f�t�H���g�̃L�[�}�b�v�ɑJ�ڂ��܂��B
		/// </summary>
		internal void TransitionDefaultKeyMap() {
			this.KeyMapChenge(this.DefaultKeyMap);
		}

		/// <summary>
		/// �L�[�}�b�v��o�^��ƂȂ�Grid �N���X����폜���s���܂��B
		/// </summary>
		internal void RemoveKeyMap() {

			//�L�[�}�b�v���o�^����Ă��Ȃ��ꍇ�X�L�b�v
			if(this.NowMap==null) {
				return;
			}

			//�L�[�}�b�v��o�^��ƂȂ�Grid �N���X����폜
			this.PiarentGrid.Children.Remove(NowMap);
			this.NowMap=null;

		}

		/// <summary>
		/// �L�[�}�b�v�̕ύX�������s���܂��B
		/// </summary>
		/// <param name="newMap">�J�ڐ�̃L�[�}�b�v�B</param>
		private void KeyMapChenge(KeyMap newMap) {

			//�L�[�}�b�v���o�^����Ă���ꍇ��o�^��ƂȂ�Grid �N���X����폜
			if(this.NowMap!=null) {
				this.PiarentGrid.Children.Remove(NowMap);
			}

			//�J�ڐ�ƂȂ�L�[�}�b�v��Grid �N���X�ɓo�^
			this.PiarentGrid.Children.Add(newMap);
			this.NowMap=newMap;

		}

		#endregion

		#region �L�[�g�b�v�\����m���[�h����

		/// <summary>
		/// �L�[�g�b�v�ɕ\������摜�����[�h���܂��B
		/// </summary>
		internal void LoadKeyTopImage() {
			this.KeyTopUpdateTask=new Task(new Action(this.LoadKeyTopImageTaskMethod));
			this.KeyTopUpdateTask.Start();
		}

		/// <summary>
		/// �L�[�g�b�v�̕\������摜�����[�h����X���b�h���Ŏ��s���郁�\�b�h�B
		/// </summary>
		internal void LoadKeyTopImageTaskMethod() {

			//�X���b�h�L�����Z���g�[�N���𐶐�
			this.KeyTopUpdateTokenSource=new CancellationTokenSource();
			try {

				//�L�[�g�b�v�ɕ\������摜�̃��[�h����
				foreach(var keyMap in this) {
					keyMap.Value.LoadKeyTopImage(this.KeyTopUpdateTokenSource.Token);
				}

				//�L�[�g�b�v�̒ǉ��摜�̃��[�h����
				foreach(var keyMap in this) {
					keyMap.Value.LoadKeyTopAdvancedImage(this.KeyTopUpdateTokenSource.Token);
				}

			} catch(OperationCanceledException) { 
			} finally {

				//�X���b�h�L�����Z���g�[�N�����N���A
				this.KeyTopUpdateTokenSource=null;

			}
		}

		/// <summary>
		/// �L�[�g�b�v�̕\�����L�����Z�����܂��B
		/// </summary>
		internal void KeyTopUpdataCancel() {

			//�L�[�g�b�v�\���X�V�X���b�h�̃g�[�N�����L�����Z���ɐݒ�
			this.KeyTopUpdateTokenSource?.Cancel();
			

			//�L�[�g�b�v�\���X�V�X���b�h�̏I����ҋ@
			this.KeyTopUpdateTask?.Wait();

			this.KeyTopUpdateTokenSource=null;
			this.KeyTopUpdateTask=null;

		}

		/// <summary>
		/// �L�[�g�b�v�̕\����񓯊��ɃL�����Z�����܂��B
		/// </summary>
		internal async void KeyTopUpdataCancelAsync() {
			await Task.Run(new Action(this.KeyTopUpdataCancel));
		}

		#endregion

	}
}