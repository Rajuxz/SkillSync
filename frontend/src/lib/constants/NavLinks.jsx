import { FaGear, FaCodeCompare } from 'react-icons/fa6';
import { FaBezierCurve } from 'react-icons/fa';
import { GoDependabot } from 'react-icons/go';
import { IoMdHelpCircle } from 'react-icons/io';
import { CiLogout } from 'react-icons/ci';
import { MdDashboard } from 'react-icons/md';

const SIDEBAR_ITEMS = [
  {
    key: 'dashboard',
    label: 'Dashboard',
    link: '/dashboard',
    icon: <MdDashboard />,
  },
  {
    key: 'compare',
    label: 'Compare CV',
    link: '/compare',
    icon: <FaCodeCompare />,
  },
  {
    key: 'learning',
    label: 'Learning',
    link: '/learning',
    icon: <FaBezierCurve />,
  },
  {
    key: 'bots',
    label: 'Bots',
    link: '/bots',
    icon: <GoDependabot />,
  },
];

const BOTTOM_LINKS = [
  {
    key: 'settings',
    label: 'Settings',
    link: '#',
    icon: <FaGear />,
  },
  {
    key: 'help',
    label: 'Help',
    link: '#',
    icon: <IoMdHelpCircle />,
  },
  {
    key: 'logout',
    label: 'Log Out',
    link: '#',
    icon: <CiLogout />,
  },
];

export { SIDEBAR_ITEMS, BOTTOM_LINKS };
