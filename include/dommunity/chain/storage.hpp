#ifndef DOMMUNITY_CHAIN_STORAGE_HPP_INCLUDED
#define DOMMUNITY_CHAIN_STORAGE_HPP_INCLUDED

namespace dommunity::chain {
	class storage {
	public:
		storage(storage const &) = delete;
		virtual ~storage() noexcept;

		storage &operator=(storage const &) = delete;

	protected:
		storage() noexcept;
	};
}

#endif // DOMMUNITY_CHAIN_STORAGE_HPP_INCLUDED
