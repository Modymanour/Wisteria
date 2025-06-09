import '@/app/navbar.css';
import { Search, Bell } from 'lucide-react';
import { Input } from '@/components/ui/input';
import { Button } from '@/components/ui/button';
import { Avatar } from '@heroui/avatar';
import Image from 'next/image';
import W from '@/app/letter-w.png'; // Adjust this path as needed

const Header = () => (
  <header className="header">
    <div className="header-container">
      <div className="header-inner">
        <div className="logo-section">
          <a href="/" className="logo-link">
            <Image src={W} alt="Wisteria Logo" height={32} width={32} />
            <span className="logo-text">Wisteria</span>
          </a>
        </div>

        <div className="search-wrapper">
          <div className="search-container">
            <Search className="search-icon" />
            <Input 
              placeholder="Search for art, music, or creators..."
              className="search-input"
            />
          </div>
        </div>

        <div className="user-actions">
          <Button variant="ghost" size="sm" className="notification-button">
            <Bell className="notification-icon" />
          </Button>
          <a href="/profile">
            <Avatar showFallback name="YU" src="/placeholder.svg" />
          </a>
        </div>
      </div>
    </div>
  </header>
);

export default Header;
