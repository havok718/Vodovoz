using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vodovoz.Models;

namespace Vodovoz.Stores
{
    internal class StaffStore
    {
        private readonly Main _main;
        private readonly Lazy<Task> _initializeLazy;
        private readonly List<StaffMember> _staffMembers;

        public IEnumerable<StaffMember> StaffMembers => _staffMembers;

        public event Action<StaffMember>? StaffMemberAdded;
        public event Action<StaffMember>? StaffMemberRemoved;

        public StaffStore(Main main)
        {
            _main = main;
            _staffMembers = new List<StaffMember>();
            _initializeLazy = new Lazy<Task>(Initialize);
        }

        private async Task Initialize()
        {
            IEnumerable<StaffMember> staffMembers = await _main.GetAllStaffMembers();

            _staffMembers.Clear();
            _staffMembers.AddRange(staffMembers);
        }

        public async Task Load()
        {
            await _initializeLazy.Value;
        }

        public async Task AddStaffMember(StaffMember staffMember)
        {
            await _main.AddStaffMember(staffMember);
            _staffMembers.Add(staffMember);

            OnStaffMemberAdded(staffMember);
        }

        private void OnStaffMemberAdded(StaffMember staffMember)
        {
            StaffMemberAdded?.Invoke(staffMember);
        }

        public async Task EditStaffMember(StaffMember staffMember)
        {
            await _main.EditStaffMember(staffMember);

            for (int i = 0; i < _staffMembers.Count; i++)
            {
                if (_staffMembers[i].Id == staffMember.Id)
                {
                    _staffMembers[i] = staffMember;
                }
            }
        }

        public async Task RemoveStaffMember(StaffMember staffMember)
        {
            OnStaffMemberRemoved(staffMember);
            await _main.RemoveStaffMember(staffMember.Id);
            _staffMembers.Remove(staffMember);
        }

        private void OnStaffMemberRemoved(StaffMember staffMember)
        {
            StaffMemberRemoved?.Invoke(staffMember);
        }
    }
}
