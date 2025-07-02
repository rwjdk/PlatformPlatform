import { t } from "@lingui/core/macro";
import { Trans } from "@lingui/react/macro";
import { LocaleSwitcher } from "@repo/infrastructure/translations/LocaleSwitcher";
import { Breadcrumb, Breadcrumbs } from "@repo/ui/components/Breadcrumbs";
import { ThemeModeSelector } from "@repo/ui/theme/ThemeModeSelector";
import { SupportPanelButton } from "@repo/ui/components/SupportPanelButton";
import type { ReactNode } from "react";
import { lazy } from "react";

const AvatarButton = lazy(() => import("account-management/AvatarButton"));

interface TopMenuProps {
  children?: ReactNode;
}

export function TopMenu({ children }: Readonly<TopMenuProps>) {
  return (
    <nav className="flex w-full items-center justify-between">
      <Breadcrumbs>
        <Breadcrumb>
          <Trans>Home</Trans>
        </Breadcrumb>
        {children}
      </Breadcrumbs>
      <div className="flex flex-row items-center gap-6">
        <span className="flex gap-2">
          <ThemeModeSelector aria-label={t`Toggle theme`} />
          <SupportPanelButton />
          <LocaleSwitcher aria-label={t`Select language`} />
        </span>
        <AvatarButton aria-label={t`User profile menu`} />
      </div>
    </nav>
  );
}
