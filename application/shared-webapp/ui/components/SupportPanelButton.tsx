import { t } from "@lingui/core/macro";
import { Button } from "./Button";
import { Dialog, DialogTrigger } from "./Dialog";
import { Modal } from "./Modal";
import { MessageCircleIcon } from "lucide-react";

export function SupportPanelButton() {
  return (
    <DialogTrigger>
      <Button variant="icon" aria-label={t`Support`}>
        <MessageCircleIcon size={20} />
      </Button>
      <Modal position="right" fullSize={true}>
        <Dialog className="w-80" aria-label={t`Support panel`}></Dialog>
      </Modal>
    </DialogTrigger>
  );
}
