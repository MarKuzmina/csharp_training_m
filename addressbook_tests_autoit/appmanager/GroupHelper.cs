using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPDELETEWIN = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetText", "#0|#" + i, "");
                list.Add(new GroupData() { Name = item });
            }
            CloseGroupDialogue();
            return list;
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");//кнопка new
            aux.Send(newGroup.Name);//вводим название группы
            aux.Send("{ENTER}");//нажимаем ВВОД
            CloseGroupDialogue();
        }

        public void Remove(GroupData delGroup)
        {
            OpenGroupsDialogue();
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
               "Select", "#0|" + delGroup.Name, "");// выделить группу удаляемую группу
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");//нажать  delete
            aux.ControlClick(GROUPDELETEWIN, "", "WindowsForms10.BUTTON.app.0.2c908d53");//нажать кнопку ОК
            CloseGroupDialogue();
        }

        public void Remove(int index)
        {
            OpenGroupsDialogue();
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
               "Select", "#0|#" + index, "");// выделить группу удаляемую группу
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");//нажать  delete
            aux.WinWait(GROUPDELETEWIN);
            aux.ControlClick(GROUPDELETEWIN, "", "WindowsForms10.BUTTON.app.0.2c908d53");//нажать кнопку ОК в форме
            aux.WinWaitActive(GROUPWINTITLE);
            CloseGroupDialogue();
        }

        private void CloseGroupDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");//кнопка close
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");//кнопка добавить группу
            aux.WinWait(GROUPWINTITLE);
        }
    }
}